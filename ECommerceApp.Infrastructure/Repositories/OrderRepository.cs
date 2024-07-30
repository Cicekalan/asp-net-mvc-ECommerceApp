using System.Linq.Expressions;
using ECommerceApp.Core;
using ECommerceApp.Core.Interfaces;
using ECommerceApp.Core.Models;
using ECommerceApp.Infrastructure.Data;

namespace ECommerceApp.Infrastructure.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Result<Order>> AddOrderAsync(Order order)
        {
            return await AddAsync(order);
        }

        public async Task<Result<IEnumerable<Order>>> GetPurchasesByUserIdAsync(string userId)
        {
            var includes = new (Expression<Func<Order, object>> include, Expression<Func<object, object>>[] thenIncludes)[]
            {
                (o => o.Customer, Array.Empty<Expression<Func<object, object>>>()),
                (o => o.Seller, Array.Empty<Expression<Func<object, object>>>()),
                (o => o.OrderItems, new Expression<Func<object, object>>[] { ot => ((OrderItem)ot).Product }) 
            };
            return await GetAllInculedeThenInculudeveAsync(filter: o => userId == o.CustomerId, includes );
        }

        public async Task<Result<IEnumerable<Order>>> GetSalesByUserIdAsync(string userId)
        {
       var includes = new (Expression<Func<Order, object>> include, Expression<Func<object, object>>[] thenIncludes)[]
        {
            (o => o.Customer, Array.Empty<Expression<Func<object, object>>>()),
            (o => o.Seller, Array.Empty<Expression<Func<object, object>>>()),
            (o => o.OrderItems, new Expression<Func<object, object>>[] { ot => ((OrderItem)ot).Product }) 
        };
            return await GetAllInculedeThenInculudeveAsync(filter: o => userId == o.SellerId, includes );
        }
    }
}
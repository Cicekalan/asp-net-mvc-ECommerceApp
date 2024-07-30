using ECommerceApp.Core;
using ECommerceApp.Core.Interfaces;
using ECommerceApp.Core.Models;
using ECommerceApp.Infrastructure.Data;

namespace ECommerceApp.Infrastructure.Repositories
{
    public class OrderItemRepository : BaseRepository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Result<OrderItem>> AddOrderItemAsync(OrderItem orderItem)
        {
            return await AddAsync(orderItem);
        }

        public Task<Result<IEnumerable<OrderItem>>> GetAllOrderItemAsync(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
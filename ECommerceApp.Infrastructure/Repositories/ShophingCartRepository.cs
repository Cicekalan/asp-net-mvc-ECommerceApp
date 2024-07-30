using System.Linq.Expressions;
using ECommerceApp.Application.Interfaces;
using ECommerceApp.Core;
using ECommerceApp.Core.Interfaces;
using ECommerceApp.Core.Models;
using ECommerceApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApp.Infrastructure.Repositories
{
    public class ShoppingCartRepository : BaseRepository<ShoppingCart>, IShoppingCartRepository
    {
        public ShoppingCartRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Result<ShoppingCart>> GetCartByCustomerIdAsync(string customerId)
        {
            var cartResult = await GetAllInculedeAsync(filter: sc => sc.CustomerId == customerId);

            if (!cartResult.Success || !cartResult.Data!.Any())
            {
                return new Result<ShoppingCart>(false, "Shopping cart not found.", null);
            }
            var shoppingCart = cartResult.Data!.FirstOrDefault();
            return new Result<ShoppingCart>(true, "Shopping cart found.", shoppingCart);
        }
    }
}

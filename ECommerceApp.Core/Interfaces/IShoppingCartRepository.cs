using ECommerceApp.Core;
using ECommerceApp.Core.Interfaces;
using ECommerceApp.Core.Models;

namespace ECommerceApp.Application.Interfaces
{
    public interface IShoppingCartRepository : IBaseRepository<ShoppingCart>
    {
        Task<Result<ShoppingCart>> GetCartByCustomerIdAsync(string customerId);
    }
}
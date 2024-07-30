using ECommerceApp.Application.DTOs;
using ECommerceApp.Core;
using ECommerceApp.Core.Models;

namespace ECommerceApp.Application.Interfaces
{
    public interface IShoppingCartService
    {        
        Task<Result<ShoppingCart>> GetCartByCustomerIdAsync(string customerId);
        Task<Result<CartItem>> AddItemToCartAsync(string customerId,CartItemDTO cartItemDTO);
        Task<Result<CartItem>> RemoveItemFromCartAsync(string customerId, int productId);
        Task<Result<IEnumerable<CartItem>>> GetCartItemsAsync(string customerId);
        Task<Result<CartItem>> RemoveAllItemFromCartAsync(string customerId, int productId);
        Task<int> GetCartItemsCountAsync(string customerId);

    }
}
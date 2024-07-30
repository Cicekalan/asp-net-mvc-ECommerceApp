using ECommerceApp.Core.Models;

namespace ECommerceApp.Core.Interfaces
{
    public interface ICartItemRepository : IBaseRepository<CartItem>
    {
        Task<Result<CartItem>> AddItemToCartAsync(CartItem cartItem);
        Task<Result<CartItem>> RemoveItemFromCartAsync(int ShoppingCartId, int productId);
        Task<Result<CartItem>> RemoveAllItemFromCartAsync(int ShoppingCartId, int productId);
        Task<Result<IEnumerable<CartItem>>> GetCartItemsAsync(int ShoppingCartId,string customerId);
    }
}
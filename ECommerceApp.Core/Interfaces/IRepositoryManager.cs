using ECommerceApp.Application.Interfaces;

namespace ECommerceApp.Core.Interfaces
{
    public interface IRepositoryManager
    {
        IProductRepository ProductRepository { get; }
        ICategoryRepository CategorRepository { get; }
        IShoppingCartRepository ShoppingCartRepository { get; }
        ICartItemRepository CartItemRepository { get; }
        IReviewRepository ReviewRepository { get; }
        IOrderRepository OrderRepository {get;}
        IOrderItemRepository OrderItemRepository { get; }
    }
}
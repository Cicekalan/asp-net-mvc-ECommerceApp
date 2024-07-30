namespace ECommerceApp.Application.Interfaces
{
    public interface IServiceManager
    {
        IProductService ProductService { get; }
        ICategoryService CategoryService { get; }
        IAuthService AuthService { get; }
        IShoppingCartService ShoppingCartService { get; }
        IReviewService ReviewService {get;}
        IOrderService  OrderService { get; }
        
    }
}
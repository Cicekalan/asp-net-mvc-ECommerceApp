using ECommerceApp.Application.Interfaces;

namespace ECommerceApp.Application.Services
{
    public class ServiceManager : IServiceManager
    {

        public readonly IProductService _productService;
        public readonly ICategoryService _categoryService;
        private readonly IAuthService _authService;
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IReviewService _reviewService;
        private readonly IOrderService _orderService;

        public ServiceManager(IProductService productService, ICategoryService categoryService, IAuthService authService, IShoppingCartService shoppingCartService, IReviewService reviewService, IOrderService orderService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _authService = authService;
            _shoppingCartService = shoppingCartService;
            _reviewService = reviewService;
            _orderService = orderService;
        }

        public IProductService ProductService => _productService;
        public ICategoryService CategoryService => _categoryService;
        public IAuthService AuthService => _authService;
        public IShoppingCartService ShoppingCartService => _shoppingCartService;
        public IReviewService ReviewService => _reviewService;
        public IOrderService OrderService => _orderService;
    }
}
using ECommerceApp.Application.Interfaces;
using ECommerceApp.Core.Interfaces;
using ECommerceApp.Infrastructure.Data;

namespace ECommerceApp.Infrastructure.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly AppDbContext _context;
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly ICartItemRepository _cartItemRepository;
        private readonly IReviewRepository _reviewRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderItemRepository  _orderItemRepository;
        public RepositoryManager(AppDbContext context, IProductRepository productRepository, ICategoryRepository categoryRepository, IShoppingCartRepository shoppingCartRepository, ICartItemRepository cartItemRepository, IReviewRepository reviewRepository, IOrderRepository orderRepository , IOrderItemRepository orderItemRepository)
        {
            _context = context;
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _shoppingCartRepository = shoppingCartRepository;
            _cartItemRepository = cartItemRepository;
            _reviewRepository = reviewRepository;
            _orderRepository = orderRepository;
            _orderItemRepository = orderItemRepository;
        }


        public IProductRepository ProductRepository => _productRepository;
        public ICategoryRepository CategorRepository => _categoryRepository;
        public IShoppingCartRepository ShoppingCartRepository => _shoppingCartRepository;

        public ICartItemRepository CartItemRepository => _cartItemRepository;

        public IReviewRepository ReviewRepository => _reviewRepository;

        public IOrderRepository OrderRepository => _orderRepository;

        public IOrderItemRepository OrderItemRepository => _orderItemRepository;
    }
}
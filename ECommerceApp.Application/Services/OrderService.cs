using AutoMapper;
using ECommerceApp.Application.Interfaces;
using ECommerceApp.Core;
using ECommerceApp.Core.Interfaces;
using ECommerceApp.Core.Models;

namespace ECommerceApp.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;
        private readonly IShoppingCartService _shoppingCartService;

        public OrderService(IRepositoryManager manager, IMapper mapper, IShoppingCartService shoppingCartService)
        {
            _manager = manager;
            _mapper = mapper;
            _shoppingCartService = shoppingCartService;
        }

        public async Task<Result<Order>> AddOrderAsync(string paymentId, string userId)
        {
            var cartItems = await _shoppingCartService.GetCartItemsAsync(userId);
            foreach(var cartItem in cartItems.Data!)
            {
                var order = new Order(){
                    OrderDate = DateTime.Now,
                    PaymentId = paymentId,
                    CustomerId = userId,
                    SellerId = cartItem.Product.SellerId,
                    TotalAmount = cartItem.Product.Price * cartItem.Quantity
                };
     
                var result = await _manager.OrderRepository.AddOrderAsync(order);
                if(result.Success)
                {
                    var orderItem = new OrderItem(){
                        OrderId = result.Data!.OrderId,
                        Price = cartItem.Product.Price,
                        Quantity = cartItem.Quantity,
                        ProductId = cartItem.ProductId
                    };

                    var resultOrderItem = await _manager.OrderItemRepository.AddOrderItemAsync(orderItem);
                    if(!resultOrderItem.Success)
                    {
                        return new Result<Order>(true, "Failed to add order item.", null); // payment refund 
                    }
                    await _shoppingCartService.RemoveAllItemFromCartAsync(userId, cartItem.Product.ProductId);
                }
                else
                {
                    return new Result<Order>(true, "Failed to add order.", null); // payment refund 
                }

            }   
            return new Result<Order>(true, "Succes to add order.", null);

        }

        public Task<Result<IEnumerable<OrderItem>>> GetAllOrderItemsByUserIdAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<IEnumerable<Order>>> GetPurchasesByUserIdAsync(string userId)
        {
            return await _manager.OrderRepository.GetPurchasesByUserIdAsync(userId);
        }

        public async Task<Result<IEnumerable<Order>>> GetSalesByUserIdAsync(string userId)
        {
            return await _manager.OrderRepository.GetSalesByUserIdAsync(userId);
        }
    }
}
using ECommerceApp.Core;
using ECommerceApp.Core.Models;

namespace ECommerceApp.Application.Interfaces
{
    public interface IOrderService
    {
        Task<Result<Order>> AddOrderAsync(string paymentId, string userId);
        Task<Result<IEnumerable<Order>>> GetPurchasesByUserIdAsync(string userId);
        Task<Result<IEnumerable<Order>>> GetSalesByUserIdAsync(string userId);
        Task<Result<IEnumerable<OrderItem>>> GetAllOrderItemsByUserIdAsync(string userId);
    }
}
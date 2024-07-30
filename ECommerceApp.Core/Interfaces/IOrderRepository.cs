using ECommerceApp.Core.Models;

namespace ECommerceApp.Core.Interfaces
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        Task<Result<Order>> AddOrderAsync(Order order);
        Task<Result<IEnumerable<Order>>> GetPurchasesByUserIdAsync(string userId);
        Task<Result<IEnumerable<Order>>> GetSalesByUserIdAsync(string userId);
    }
}
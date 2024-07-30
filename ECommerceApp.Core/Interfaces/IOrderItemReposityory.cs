using ECommerceApp.Core.Models;

namespace ECommerceApp.Core.Interfaces
{
    public interface IOrderItemRepository : IBaseRepository<OrderItem>
    {
        Task<Result<OrderItem>> AddOrderItemAsync(OrderItem orderItem);
        Task<Result<IEnumerable<OrderItem>>> GetAllOrderItemAsync(string userId);
    }
}

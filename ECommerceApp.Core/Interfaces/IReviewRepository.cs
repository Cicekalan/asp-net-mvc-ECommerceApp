using ECommerceApp.Core.Models;

namespace ECommerceApp.Core.Interfaces
{
    public interface IReviewRepository :  IBaseRepository<Review>
    {
        Task<Result<Review>> AddReviewAsync(Review review);
        Task<Result<IEnumerable<Review>>> GetReviewByProductAsync(int productId);
        Task<Result<Review>> RemoveReviewAsync(int reviewId);
    }
}
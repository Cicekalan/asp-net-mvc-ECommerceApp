using ECommerceApp.Application.DTOs;
using ECommerceApp.Core;
using ECommerceApp.Core.Models;

namespace ECommerceApp.Application.Interfaces
{
    public interface IReviewService 
    {
        Task<Result<Review>> AddReviewAsync(ReviewInsertDTO reviewDTO);
        Task<Result<IEnumerable<Review>>> GetReviewByProductAsync(int productId);
        Task<Result<Review>> RemoveReviewAsync(int reviewId);
    }
}
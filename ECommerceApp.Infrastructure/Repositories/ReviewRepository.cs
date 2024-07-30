using ECommerceApp.Core;
using ECommerceApp.Core.Interfaces;
using ECommerceApp.Core.Models;
using ECommerceApp.Infrastructure.Data;

namespace ECommerceApp.Infrastructure.Repositories
{
    public class ReviewRepository : BaseRepository<Review> , IReviewRepository
    {
        public ReviewRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Result<Review>> AddReviewAsync(Review review)
        {
            return await AddAsync(review);
        }

        public Task<Result<IEnumerable<Review>>> GetReviewByProductAsync(int productId)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<Review>> RemoveReviewAsync(int reviewId)
        {
            return await DeleteAsync(reviewId);
        }
    }
}
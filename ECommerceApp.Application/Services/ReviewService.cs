using AutoMapper;
using ECommerceApp.Application.DTOs;
using ECommerceApp.Application.Interfaces;
using ECommerceApp.Core;
using ECommerceApp.Core.Interfaces;
using ECommerceApp.Core.Models;

namespace ECommerceApp.Application.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public ReviewService(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }
        public async Task<Result<Review>> AddReviewAsync(ReviewInsertDTO reviewDTO)
        {
            var review = _mapper.Map<Review>(reviewDTO);
            return await _manager.ReviewRepository.AddAsync(review);
        }

        public async Task<Result<IEnumerable<Review>>> GetReviewByProductAsync(int productId)
        {
            return await _manager.ReviewRepository.GetAllAsync();
        }

        public async Task<Result<Review>> RemoveReviewAsync(int reviewId)
        {
            return await _manager.ReviewRepository.RemoveReviewAsync(reviewId);
        }
    }
}
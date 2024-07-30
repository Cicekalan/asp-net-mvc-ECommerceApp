using ECommerceApp.Application.Interfaces;
using ECommerceApp.Core;
using ECommerceApp.Core.Models;
using ECommerceApp.Core.Interfaces;

namespace ECommerceApp.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepositoryManager _manager;

        public CategoryService(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public async Task<Result<Category>> AddCategoryAsync(Category category)
        {
            return await _manager.CategorRepository.AddCategoryAsync(category);
        }

        public Task<Result<Category>> DeleteCategoryAsync(int id)
        {
           return _manager.CategorRepository.DeleteCategoryAsync(id);
        }

        public Task<Result<IEnumerable<Category>>> GetAllCategoryAsync()
        {
            return _manager.CategorRepository.GetAllCategoryAsync();
        }

        public Task<Result<Category>> GetByIdCategoryAsync(int id)
        {
            return _manager.CategorRepository.GetByIdCategoryAsync(id);
        }

        public async Task<Result<Category>> UpdateCategoryAsync(Category category)
        {
            return await _manager.CategorRepository.UpdateCategoryAsync(category);
        }
    }

}
using ECommerceApp.Core;
using ECommerceApp.Core.Interfaces;
using ECommerceApp.Core.Models;
using ECommerceApp.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;

namespace ECommerceApp.Infrastructure.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
            
        }

        public async Task<Result<Category>> AddCategoryAsync(Category category)
        {
            return await AddAsync(category);
        }

        public async Task<Result<Category>> DeleteCategoryAsync(int id)
        {
            return await DeleteAsync(id);
        }

        public async Task<Result<IEnumerable<Category>>> GetAllCategoryAsync()
        {
            return await GetAllAsync();
        }

        public async Task<Result<Category>> GetByIdCategoryAsync(int id)
        {
            return await GetByIdAsync(id);
        }

        public async Task<Result<Category>> UpdateCategoryAsync(Category category)
        {
            return await UpdateAsync(category);
        }
    }
}
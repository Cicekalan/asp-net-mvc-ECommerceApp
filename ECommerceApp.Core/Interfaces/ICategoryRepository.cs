using ECommerceApp.Core.Models;

namespace ECommerceApp.Core.Interfaces
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        Task<Result<Category>> AddCategoryAsync(Category category);
        Task<Result<Category>> DeleteCategoryAsync(int id);
        Task<Result<IEnumerable<Category>>> GetAllCategoryAsync();
        Task<Result<Category>> GetByIdCategoryAsync(int id);
        Task<Result<Category>> UpdateCategoryAsync(Category category);
    }
}
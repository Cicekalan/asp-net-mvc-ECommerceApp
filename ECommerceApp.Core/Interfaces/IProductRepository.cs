using ECommerceApp.Core.Models;
using System.Linq.Expressions;

namespace ECommerceApp.Core.Interfaces
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<Result<IEnumerable<Product>>> GetProductsByCategoryAsync(string categoryName);
        Task<Result<Product>> AddProductAsync(Product product);
        Task<Result<Product>> DeleteProductAsync(int id);
        Task<Result<IEnumerable<Product>>> GetAllProductAsync();
        Task<Result<Product>> GetByIdProductAsync(int id);
        Task<Result<Product>> UpdateProductAsync(Product product);
        Task<Result<IEnumerable<Product>>> GetFilteredProductsAsync(Expression<Func<Product, bool>> filter, string sortOrder);
        Task<Result<IEnumerable<Product>>> GetFilteredProductsByCategoryAsync(Expression<Func<Product, bool>> filter, string categoryName);
        Task<Result<IEnumerable<Product>>> GetAllProductInculudeAndFilteredAsync(Expression<Func<Product, bool>> filter, params Expression<Func<Product, object>>[] inculude);
        Task<Result<IEnumerable<Product>>> GetByProductAsync(Expression<Func<Product, bool>> filter, params Expression<Func<Product, object>>[] inculude);
        Task<Result<IEnumerable<Product>>> GetAllInculedeThenInculudeveAsync(int productId);
    }
}
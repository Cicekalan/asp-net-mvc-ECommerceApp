using System.Linq.Expressions;
using ECommerceApp.Application.DTOs;
using ECommerceApp.Core;
using ECommerceApp.Core.Models;

namespace ECommerceApp.Application.Interfaces
{
    public interface IProductService
    {
        Task<Result<Product>> AddProductAsync(ProductInsertDTO productInsertDTO);
        Task<Result<Product>> GetProductByIdAsync(int id);
        Task<Result<IEnumerable<Product>>> GetAllProductsAsync();
        Task<Result<IEnumerable<Product>>> GetProductsByCategoryAsync(string categoryName);
        Task<Result<IEnumerable<Product>>> GetFilteredProductsAsync(Expression<Func<Product, bool>> filter, string sortOrder);
        Task<Result<Product>> UpdateProductAsync(Product product);
        Task<Result<Product>> DeleteProductAsync(int id);
        Task<Result<IEnumerable<Product>>> GetFilteredProductsByCategoryAsync(Expression<Func<Product, bool>> filter, string categoryName);
        Task<Result<IEnumerable<Product>>> GetAllProductInculudeAndFilteredAsync(Expression<Func<Product, bool>> filter, params Expression<Func<Product, object>>[] inculude);
        Task<Result<IEnumerable<Product>>> GetByProductAsync(Expression<Func<Product, bool>> filter, params Expression<Func<Product, object>>[] inculude);
        Task<Result<IEnumerable<Product>>> GetAllInculedeThenInculudeveAsync(int productId);

    
    }
}
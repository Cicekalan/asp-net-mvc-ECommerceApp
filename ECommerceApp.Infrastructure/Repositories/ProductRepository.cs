using ECommerceApp.Core.Models;
using ECommerceApp.Core.Interfaces;
using ECommerceApp.Infrastructure.Data;
using ECommerceApp.Core;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApp.Infrastructure.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Result<Product>> AddProductAsync(Product product)
        {
            return await AddAsync(product);
        }

        public async Task<Result<Product>> DeleteProductAsync(int id)
        {
            return await DeleteAsync(id);
        }

        public async Task<Result<IEnumerable<Product>>> GetAllInculedeThenInculudeveAsync(int productId)
        {
            Expression<Func<Product, bool>> filter = p => p.ProductId == productId;

            var includes = new (Expression<Func<Product, object>> include, Expression<Func<object, object>>[] thenIncludes)[]
            {
                (p => p.Category, Array.Empty<Expression<Func<object, object>>>()),
                (p => p.Seller, Array.Empty<Expression<Func<object, object>>>()),
                (p => p.Reviews, new Expression<Func<object, object>>[] { r => ((Review)r).Customer })
            };

            return await GetAllInculedeThenInculudeveAsync(filter, includes);
        }

        public async Task<Result<IEnumerable<Product>>> GetAllProductAsync()
        {
            return await GetAllAsync();
        }
        public async Task<Result<IEnumerable<Product>>> GetAllProductByCategoryAsync()
        {
            return await GetAllInculedeAsync(includes: p => p.Category);
        }

        public async Task<Result<IEnumerable<Product>>> GetAllProductInculudeAndFilteredAsync(Expression<Func<Product, bool>> filter, params Expression<Func<Product, object>>[] inculude)
        {
            return await GetAllInculedeAsync(filter, inculude);
        }
        public async Task<Result<Product>> GetByIdProductAsync(int id)
        {
            return await GetByIdProductAsync(id);
        }

        public async Task<Result<IEnumerable<Product>>> GetByProductAsync(Expression<Func<Product, bool>> filter=null!, params Expression<Func<Product, object>>[] inculude )
        {
            return await GetFilteredAsync();
        }

        public async Task<Result<IEnumerable<Product>>> GetFilteredProductsAsync(Expression<Func<Product, bool>> filter, string sortOrder)
        {
            return await GetFilteredAsync(filter);
        }

        public async Task<Result<IEnumerable<Product>>> GetFilteredProductsByCategoryAsync(Expression<Func<Product, bool>> filter, string categoryName)
        {
            Expression<Func<Product, bool>> categoryFilter = p => p.Category.Name == categoryName;
            Expression<Func<Product, bool>> combinedFilter = p => (filter == null || filter.Compile()(p)) && categoryFilter.Compile()(p);
            return await GetFilteredAsync(combinedFilter);
        }

        public async Task<Result<IEnumerable<Product>>> GetProductsByCategoryAsync(string categoryName)
        {

            return await GetFilteredAsync(p => p.Category.Name == categoryName);
        }

        public async Task<Result<Product>> UpdateProductAsync(Product product)
        {
            return await UpdateAsync(product);
        }
    }
}
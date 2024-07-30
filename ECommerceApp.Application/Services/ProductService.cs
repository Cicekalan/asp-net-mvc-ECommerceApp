using ECommerceApp.Application.Interfaces;
using ECommerceApp.Core.Models;
using ECommerceApp.Core;
using ECommerceApp.Core.Interfaces;
using System.Linq.Expressions;
using ECommerceApp.Application.DTOs;
using AutoMapper;

namespace ECommerceApp.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public ProductService(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<Result<Product>> AddProductAsync(ProductInsertDTO productInsertDTO)
        {
            var product = _mapper.Map<Product>(productInsertDTO);
            return await _manager.ProductRepository.AddProductAsync(product);
        }

        public async Task<Result<Product>> GetProductByIdAsync(int id)
        {
            return await _manager.ProductRepository.GetByIdProductAsync(id);
        }

        public async Task<Result<IEnumerable<Product>>> GetAllProductsAsync()
        {
            return await _manager.ProductRepository.GetAllProductAsync();
        }

        public async Task<Result<IEnumerable<Product>>> GetProductsByCategoryAsync(string categoryName)
        {
            return await _manager.ProductRepository.GetProductsByCategoryAsync(categoryName);
        }

        public async Task<Result<Product>> UpdateProductAsync(Product product)
        {
            return await _manager.ProductRepository.UpdateProductAsync(product);
        }

        public async Task<Result<Product>> DeleteProductAsync(int id)
        {
            return await _manager.ProductRepository.DeleteProductAsync(id);
        }

        public async Task<Result<IEnumerable<Product>>> GetFilteredProductsAsync(Expression<Func<Product, bool>> filter, string sortOrder)
        {
            return await _manager.ProductRepository.GetFilteredProductsAsync(filter, sortOrder);
        }

        public async Task<Result<IEnumerable<Product>>> GetFilteredProductsByCategoryAsync(Expression<Func<Product, bool>> filter, string categoryName)
        {
            return await _manager.ProductRepository.GetFilteredProductsByCategoryAsync(filter, categoryName);
        }

        public async Task<Result<IEnumerable<Product>>> GetAllProductInculudeAndFilteredAsync(Expression<Func<Product, bool>> filter, params Expression<Func<Product, object>>[] inculude)
        {
            return await _manager.ProductRepository.GetAllProductInculudeAndFilteredAsync(filter,inculude);
        }

        public async Task<Result<IEnumerable<Product>>> GetByProductAsync(Expression<Func<Product, bool>> filter, params Expression<Func<Product, object>>[] inculude)
        {
            return await _manager.ProductRepository.GetByProductAsync(filter, inculude);
        }

        public async Task<Result<IEnumerable<Product>>> GetAllInculedeThenInculudeveAsync(int productId)
        {
            return await _manager.ProductRepository.GetAllInculedeThenInculudeveAsync(productId);
        }
    }
}
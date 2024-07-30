using System.Linq.Expressions;
using ECommerceApp.Application.DTOs;
using ECommerceApp.Application.Interfaces;
using ECommerceApp.Core.Models;
using ECommerceApp.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IServiceManager _manager;
        private readonly UserManager<ApplicationUser> _userManager;
        public ProductController(IServiceManager manager, UserManager<ApplicationUser> userManager)
        {
            _manager = manager;
            _userManager = userManager;
        }
        [HttpGet("Index")]
        [HttpGet("Product/{categoryName?}")]
        public async Task<IActionResult> Index(string? categoryName = null, decimal? minPrice = null, decimal? maxPrice = null, bool sorted = false)
        {
            ViewBag.CurrentPage = "Index";
            ViewBag.PageTitle = "Products";
            IEnumerable<Product> products;

            Expression<Func<Product, bool>> filter = p =>
                (!minPrice.HasValue || p.Price >= minPrice.Value) &&
                (!maxPrice.HasValue || p.Price <= maxPrice.Value) &&
                (string.IsNullOrEmpty(categoryName) || p.Category.Name == categoryName);

            Expression<Func<Product, object>>[] includes = new Expression<Func<Product, object>>[]{
                    p => p.Category,
                    p => p.Seller,
                    p => p.Reviews};

            var result = await _manager.ProductService.GetAllProductInculudeAndFilteredAsync(filter, includes);
            products = result.Data ?? new List<Product>();

            var viewModel = new ProductListViewModel
            {
                Products = products,
                Filter = new FilterViewModel
                {
                    MinPrice = minPrice,
                    MaxPrice = maxPrice,
                    SortOrder = sorted ? "Sorted" : "Unsorted",
                    CategoryName = categoryName
                }
            };

            return View(viewModel);
        }
        [HttpGet("Product/Details/{productId?}")]
        public async Task<IActionResult> Details(int productId)
        {
                
            var result = await _manager.ProductService.GetAllInculedeThenInculudeveAsync(productId);
            var user = await _userManager.GetUserAsync(User);
            var product = result.Data!.FirstOrDefault();
            if (result.Success)
            {
                var model = new ProductByReviewDetailViewModel
                {
                    Product = product!,
                    ReviewInsertDTO = new ReviewInsertDTO
                    {
                        ProductId = product!.ProductId,
                        CustomerId = user?.Id ?? string.Empty
                    }
                };
                return View(model);
            }
            else
            {
                return NotFound();
            }

        }
        [Authorize]
        [HttpGet("Product/AddProduct")]
        public async Task<IActionResult> AddProduct()
        {
            var categories = await _manager.CategoryService.GetAllCategoryAsync();
            var viewModel = new ProductInsertViewModel
            {
                Categories = categories.Data!
            };
            return View(viewModel);
        }
        [Authorize]
        [HttpPost("Product/AddProduct")]
        public async Task<IActionResult> AddProduct(ProductInsertViewModel viewModel, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                string path = Path.Combine(Directory.GetCurrentDirectory()
                , "wwwroot", "images", file.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                var product = viewModel.Product;

                var user = await _userManager.GetUserAsync(User);

                product.ImageUrl = String.Concat("/images/", file.FileName);
                product.SellerId = user!.Id;

                var result = await _manager.ProductService.AddProductAsync(product);
                if (result.Success)
                {
                    return RedirectToAction("Index", "Product");
                }

            }
            var categories = await _manager.CategoryService.GetAllCategoryAsync();
            viewModel.Categories = categories.Data ?? new List<Category>();

            return View(viewModel);
        }

    }
    

}
/*
public async Task<IActionResult> Index(decimal? minPrice, decimal? maxPrice, string sortOrder = "asc", bool Sorted = false)
{
    ViewBag.CurrentPage = "Index";
    ViewBag.PageTitle = "Products";
    IEnumerable<Product> products;
    if (Sorted)
    {
        Expression<Func<Product, bool>> filter = p =>
            (!minPrice.HasValue || p.Price >= minPrice.Value) &&
            (!maxPrice.HasValue || p.Price <= maxPrice.Value);

        var result = await _manager.ProductService.GetFilteredProductsAsync(filter, sortOrder);
        products = result.Data ?? new List<Product>();
    }
    else
    {
        var result = await _manager.ProductService.GetAllProductsAsync();
        products = result.Data ?? new List<Product>();
    }

    var viewModel = new ProductListViewModel
    {
        Products = products,
        Filter = new FilterViewModel
        {
            MinPrice = minPrice,
            MaxPrice = maxPrice,
            SortOrder = sortOrder
        }
    };

    return View(viewModel);
}
*/
/*
[HttpGet("Product/{categoryName}")]
public async Task<IActionResult> ProductsByCategory(string categoryName, decimal? minPrice, decimal? maxPrice, string sortOrder = "asc", bool Sorted = false)
{
    ViewBag.PageTitle = $"Products in {categoryName} - {(Sorted ? "Sorted" : "Unsorted")}";
    ViewBag.CurrentPage = "ProductsByCategory";
    ViewBag.CategoryName = categoryName;
    IEnumerable<Product> products;
    if (Sorted)
    {
        Expression<Func<Product, bool>> filter = p =>
            (!minPrice.HasValue || p.Price >= minPrice.Value) &&
            (!maxPrice.HasValue || p.Price <= maxPrice.Value) &&
            (p.Category.Name == categoryName);

        var result = await _manager.ProductService.GetFilteredProductsAsync(filter, sortOrder);
        products = result.Data ?? new List<Product>();
    }
    else
    {
        var result = await _manager.ProductService.GetProductsByCategoryAsync(categoryName);
        products = result.Data ?? new List<Product>();
    }
    var viewModel = new ProductListViewModel
    {
        Products = products,
        Filter = new FilterViewModel
        {
            MinPrice = minPrice,
            MaxPrice = maxPrice,
            SortOrder = sortOrder
        }
    };
    return View(viewModel);
}
*/




using ECommerceApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace StoreApp.Components
{
    public class CategoryMenuViewComponent : ViewComponent
    {
        private readonly IServiceManager _manager;

        public CategoryMenuViewComponent(IServiceManager manager)
        {
            _manager = manager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _manager.CategoryService.GetAllCategoryAsync();
            return View(categories.Data);
        }
    }
}
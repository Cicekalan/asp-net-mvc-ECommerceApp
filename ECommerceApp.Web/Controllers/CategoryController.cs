using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ECommerceApp.Web.Models;
using ECommerceApp.Application.Interfaces;
using ECommerceApp.Core.Models;
using Microsoft.AspNetCore.Identity;

namespace ECommerceApp.Web.Controllers;

public class CategoryController : Controller
{


    private readonly IServiceManager _manager;

    public CategoryController(IServiceManager manager)
    {
        _manager = manager;
    }

    public async  Task<IActionResult> Index()
    {
        var categories = await _manager.CategoryService.GetAllCategoryAsync();
        return View(categories.Data);
    }

}

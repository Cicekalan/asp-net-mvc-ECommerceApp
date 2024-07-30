using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ECommerceApp.Web.Models;
using ECommerceApp.Application.Interfaces;

namespace ECommerceApp.Web.Controllers;

public class HomeController : Controller
{
    private readonly IServiceManager _manager;

    public HomeController(IServiceManager manager)
    {
        _manager = manager;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

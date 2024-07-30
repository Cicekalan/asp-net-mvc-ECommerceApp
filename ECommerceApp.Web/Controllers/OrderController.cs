using ECommerceApp.Application.Interfaces;
using ECommerceApp.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.Web.Controllers
{       
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IServiceManager _manager;
        private readonly UserManager<ApplicationUser> _userManager;
        public OrderController(IServiceManager manager, UserManager<ApplicationUser> userManager)
        {
            _manager = manager;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return RedirectToAction("MyOrdes");
        }
        [HttpGet]
        public async Task<IActionResult> MyOrders()
        {
            var user = await _userManager.GetUserAsync(User);
            var result = await _manager.OrderService.GetPurchasesByUserIdAsync(user!.Id);
            return View(result.Data);
        }
        [HttpGet]
        public async Task<IActionResult> PurchasedItems()
        {
            var user = await _userManager.GetUserAsync(User);
            var result = await _manager.OrderService.GetSalesByUserIdAsync(user!.Id);
            return View(result.Data);
        }
    }
}
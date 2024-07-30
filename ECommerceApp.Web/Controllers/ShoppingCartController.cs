using ECommerceApp.Application.Interfaces;
using ECommerceApp.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.Web.Controllers
{
    [Authorize]
    public class ShoppingCartController : Controller
    {
        private readonly IServiceManager _manager;
        private readonly UserManager<ApplicationUser> _userManager;
        public ShoppingCartController(IServiceManager manager, UserManager<ApplicationUser> userManager)
        {
            _manager = manager;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var cartItems =await _manager.ShoppingCartService.GetCartItemsAsync(user!.Id);
            return View(cartItems.Data);
        }
    }
}
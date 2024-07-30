using ECommerceApp.Application.Interfaces;
using ECommerceApp.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
namespace StoreApp.Components
{
    public class CartItemCountViewComponent : ViewComponent
    {
        private readonly IServiceManager _manager;
        private readonly UserManager<ApplicationUser> _userManager;

        public CartItemCountViewComponent(IServiceManager manager, UserManager<ApplicationUser> userManager)
        {
            _manager = manager;
            _userManager = userManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.GetUserAsync(UserClaimsPrincipal);
            int count = await _manager.ShoppingCartService.GetCartItemsCountAsync(user!.Id);
            return Content(count.ToString());
        }
    }
}
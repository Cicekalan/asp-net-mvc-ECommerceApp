using ECommerceApp.Core.Models;
using ECommerceApp.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

public class UserViewComponent : ViewComponent
{
    private readonly UserManager<ApplicationUser> _userManager;

    public UserViewComponent(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }
    [Authorize]
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var user = await _userManager.GetUserAsync(UserClaimsPrincipal);
        var userInfo = new UserInfo
        {
                FullName = user!.FullName,
                ProfilePictureUrl = user.ProfilePictureUrl!
        };
            return View("Default", userInfo);
        }
}
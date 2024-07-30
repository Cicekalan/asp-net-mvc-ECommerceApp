using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using ECommerceApp.Application.DTOs;
using ECommerceApp.Core.Models;
using ECommerceApp.Application.Interfaces;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace ECommerceApp.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IServiceManager _manager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(IServiceManager manager, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _manager = manager;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Register()
        {
            if (User.Identity is { IsAuthenticated: true })
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserRegisterDTO userDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _manager.AuthService.RegisterAsync(userDto);
                    return RedirectToAction("Index", "Home");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }

            return View(userDto);
        }
        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity is { IsAuthenticated: true })
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserLoginDTO userloginDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _manager.AuthService.LoginAsync(userloginDto);
                if (result.Succeeded)
                {
                    var user = await _userManager.FindByEmailAsync(userloginDto.Email);
                    if (user != null)
                    {
                        Response.Cookies.Append("UserId", user.Id, new CookieOptions{
                            HttpOnly = true,
                            Secure = true,
                        SameSite = SameSiteMode.Strict});
                    }
                    return RedirectToAction("Index", "Home");
                }
                if (result.IsLockedOut)
                {
                    ModelState.AddModelError(string.Empty, "Your account is locked due to multiple failed login attempts. Please try again later.");
                }
                else if (result.IsNotAllowed)
                {
                    ModelState.AddModelError(string.Empty, "Your account is not allowed to log in. Please contact support.");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid email or password. Please try again.");
                }
            }
            return View(userloginDto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _manager.AuthService.LogoutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
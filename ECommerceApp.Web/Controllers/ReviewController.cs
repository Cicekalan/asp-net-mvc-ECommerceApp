using ECommerceApp.Application.DTOs;
using ECommerceApp.Application.Interfaces;
using ECommerceApp.Core.Models;
using ECommerceApp.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ECommerceApp.Web.Controllers
{
    [Authorize]
    public class ReviewController : Controller
    {
        private readonly IServiceManager _manager;
        private readonly UserManager<ApplicationUser> _userManager;

        public ReviewController(UserManager<ApplicationUser> userManager, IServiceManager manager)
        {
            _userManager = userManager;
            _manager = manager;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> AddReview(ReviewInsertDTO model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false, errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList() });
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Json(new { success = false, message = "Unauthorized" });
            }
            var review = new ReviewInsertDTO
            {
                Content = model.Content,
                Rating = model.Rating,
                ProductId = model.ProductId,
                CustomerId = user.Id,
            };

            var result = await _manager.ReviewService.AddReviewAsync(review);
            if (result.Success)
            {
                return Json(new
                {
                    success = true,
                    message = "Review added successfully.",
                    review = new
                    {
                        content = model.Content,
                        customerFullName = user.FullName,
                        customerProfilePictureUrl = user.ProfilePictureUrl
                    }
                });
            }

            return Json(new { success = false, message = result.Message });
        }
    }
}

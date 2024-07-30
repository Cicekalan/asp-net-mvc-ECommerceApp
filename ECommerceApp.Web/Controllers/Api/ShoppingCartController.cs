using ECommerceApp.Application.DTOs;
using ECommerceApp.Application.Interfaces;
using ECommerceApp.Core.Models;
using ECommerceApp.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace ECommerceApp.Web.Controllers.Api
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IServiceManager _manager;
        private readonly UserManager<ApplicationUser> _userManager;

        public ShoppingCartController(IServiceManager manager, UserManager<ApplicationUser> userManager)
        {
            _manager = manager;
            _userManager = userManager;
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetCartByCustomerId(string customerId)
        {
            var result = await _manager.ShoppingCartService.GetCartByCustomerIdAsync(customerId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return NotFound(result.Message);
        }

        [HttpPost("AddItemToCart")]
        public async Task<IActionResult> AddItemToCart([FromBody] CartItemDTO cartItemDTO)
        {
            var user = await _userManager.GetUserAsync(User);
            var result = await _manager.ShoppingCartService.AddItemToCartAsync(user!.Id, cartItemDTO);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpDelete("remove/{productId}")]
        public async Task<IActionResult> RemoveItemFromCart(int productId)
        {
            var user = await _userManager.GetUserAsync(User);
            var result = await _manager.ShoppingCartService.RemoveItemFromCartAsync(user.Id ,productId);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpDelete("removeAll/{productId}")]
        public async Task<IActionResult> RemoveAllItemFromCart(int productId)
        {
            var user = await _userManager.GetUserAsync(User);
            var result = await _manager.ShoppingCartService.RemoveAllItemFromCartAsync(user.Id ,productId);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

    }
}
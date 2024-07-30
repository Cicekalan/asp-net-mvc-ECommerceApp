using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Iyzipay;
using Iyzipay.Model;
using Iyzipay.Request;
using ECommerceApp.Web.Models;
using ECommerceApp.Core.Models;
using Microsoft.AspNetCore.Identity;
using ECommerceApp.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System.Globalization;



namespace ECommerceApp.Web.Controllers
{

    public class PaymentController : Controller
    {
        private readonly IyzipayOptions _iyzipayOptions;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IServiceManager _manager;

        public PaymentController(IOptions<IyzipayOptions> iyzipayOptions, UserManager<ApplicationUser> userManager, IServiceManager manager)
        {
            _iyzipayOptions = iyzipayOptions.Value;
            _userManager = userManager;
            _manager = manager;
        }
        [Authorize]
        [HttpPost("Payment")]
        public async Task<IActionResult> Payment()
        {
            var user = await _userManager.GetUserAsync(User);
            var cartItems = await _manager.ShoppingCartService.GetCartItemsAsync(user!.Id);

            var basketItems = new List<BasketItem>();
            decimal basketItemsTotal = 0;
            if (cartItems?.Data != null)
            {
                foreach (var cartItem in cartItems.Data)
                {
                    if (cartItem?.Product != null && cartItem.Product.Category != null)
                    {
                        basketItemsTotal += Math.Round(cartItem.Product.Price * cartItem.Quantity,1);
                        basketItems.Add(new BasketItem
                        {
                            Id = cartItem.ProductId.ToString(),
                            Name = cartItem.Product.Name,
                            Category1 = cartItem.Product.Category.Name,
                            Category2 = cartItem.Product.Category.Name,
                            ItemType = BasketItemType.PHYSICAL.ToString(),
                            Price = Math.Round(cartItem.Product.Price * cartItem.Quantity, 1).ToString("F1", CultureInfo.InvariantCulture)
                        });
                    }
                }
            }
            else
            {
                return BadRequest("Cart items are null or empty");
            }



            var request = new CreateCheckoutFormInitializeRequest
            {
                Locale = Locale.TR.ToString(),
                ConversationId = Guid.NewGuid().ToString(),
                Price = basketItemsTotal.ToString("F1", CultureInfo.InvariantCulture),
                PaidPrice =basketItemsTotal.ToString("F1", CultureInfo.InvariantCulture),
                Currency = Currency.TRY.ToString(),
                BasketId = "B67832",
                PaymentGroup = PaymentGroup.PRODUCT.ToString(),
                CallbackUrl = Url.Action("Callback", "Payment", new { userId = user.Id }, Request.Scheme)

            };

            request.EnabledInstallments = new List<int> { 2, 3, 6, 9 };

            var buyer = new Buyer
            {
                Id = user.Id.ToString(),
                Name = user.FirstName,
                Surname = user.LastName,
                GsmNumber = user.PhoneNumber,
                Email = user.Email,
                IdentityNumber = "11111111111",//TCKN
                LastLoginDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                RegistrationDate = user.RegistrationDate.ToString("yyyy-MM-dd HH:mm:ss"),
                RegistrationAddress = user.StreetAddress,
                Ip = "85.34.78.112",
                City = user.City,
                Country = "Turkey",
                ZipCode = user.PostalCode
            };
            request.Buyer = buyer;

            var shippingAddress = new Address
            {
                ContactName = user.FirstName,
                City = user.City,
                Country = "Turkey",
                Description = user.StreetAddress,
                ZipCode = user.PostalCode
            };
            request.ShippingAddress = shippingAddress;

            var billingAddress = new Address
            {
                ContactName = user.FirstName,
                City = user.StreetAddress,
                Country = "Turkey",
                Description = user.StreetAddress,
                ZipCode = user.PostalCode
            };
            request.BillingAddress = billingAddress;

            request.BasketItems = basketItems;

            try
            {
                var checkoutFormInitialize = CheckoutFormInitialize.Create(request, _iyzipayOptions);
                if (checkoutFormInitialize.Status == "success")
                {

                    return Redirect(checkoutFormInitialize.PaymentPageUrl);
                }
                else
                {
                    return BadRequest("Payment initialization failed: " + checkoutFormInitialize.ErrorMessage);
                }
            }
            catch (UriFormatException ex)
            {
                return BadRequest("Error: " + ex.Message);
            }

        }

        [HttpPost("callback/{userId}")]
        public async Task<ActionResult> Callback(string userId,IFormCollection collections)
        {
            foreach (var key in collections.Keys)
            {
                System.Console.WriteLine($"{key}: {collections[key]}");
            }
            var token = collections["token"];
            var conversationId = collections["conversationId"];
            var request = new RetrieveCheckoutFormRequest
            {
                Token = token,
            };
            var checkoutForm = CheckoutForm.Retrieve(request, _iyzipayOptions);
            if (checkoutForm.Status == "success")
            {
                var result = await _manager.OrderService.AddOrderAsync(Guid.NewGuid().ToString(),userId! );
                if (result.Success)
                    return RedirectToAction("Index", "Product");
                else
                {
                    return BadRequest("Payment failed. Reason:" + checkoutForm.ErrorMessage);
                }
            }
            else
            {
                return BadRequest("Payment failed. Reason:" + checkoutForm.ErrorMessage);
            }
        }



    }
}

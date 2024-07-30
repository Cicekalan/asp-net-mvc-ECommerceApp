using System.Linq.Expressions;
using ECommerceApp.Core;
using ECommerceApp.Core.Interfaces;
using ECommerceApp.Core.Models;
using ECommerceApp.Infrastructure.Data;

namespace ECommerceApp.Infrastructure.Repositories
{
    public class CartItemRepository : BaseRepository<CartItem>, ICartItemRepository
    {
        public CartItemRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Result<CartItem>> AddItemToCartAsync(CartItem cartItem)
        {
            var existingCart = await GetFilteredAsync(c => c.ShoppingCartId == cartItem.ShoppingCartId && c.ProductId == cartItem.ProductId);
            if (existingCart.Success)
            {
                var changedCart = existingCart.Data!.FirstOrDefault();
                changedCart!.Quantity += 1;
                return await UpdateAsync(changedCart);
            }
            else
            {
                return await AddAsync(cartItem);
            }
        }

        public async Task<Result<IEnumerable<CartItem>>> GetCartItemsAsync(int ShoppingCartId, string customerId)
        {
            var cartItemsResult = await GetAllInculedeThenInculudeveAsync(
                filter:
                    c => c.ShoppingCartId == ShoppingCartId,
                includes:
                    (c => c.Product,new Expression<Func<object, object>>[] {c => ((Product)c).Category})
            );
            if (!cartItemsResult.Success)
            {
                return new Result<IEnumerable<CartItem>>(false, "No items found in the shopping cart.", null);
            }
            return cartItemsResult;

        }

        public async Task<Result<CartItem>> RemoveAllItemFromCartAsync(int ShoppingCartId, int productId)
        {
            var existingCart = await GetFilteredAsync(c => c.ShoppingCartId == ShoppingCartId && c.ProductId == productId);
            if (existingCart.Success)
            {
                    return await DeleteAsync(existingCart.Data!.FirstOrDefault()!.CartItemId);
            }
            else
            {
                return new Result<CartItem>(false, "Failed to remove item from the shopping cart.", null);
            }
        }

        public async Task<Result<CartItem>> RemoveItemFromCartAsync(int ShoppingCartId, int productId)
        {
            var existingCart = await GetFilteredAsync(c => c.ShoppingCartId == ShoppingCartId && c.ProductId == productId);
            if (existingCart.Success)
            {
                if (existingCart.Data!.FirstOrDefault()!.Quantity > 1)
                {
                    var changedCart = existingCart.Data!.FirstOrDefault();
                    changedCart!.Quantity -= 1;
                    return await UpdateAsync(changedCart);
                }
                else
                {
                    return await DeleteAsync(existingCart.Data!.FirstOrDefault()!.CartItemId);
                }
            }
            else
            {
                return new Result<CartItem>(false, "Failed to remove item from the shopping cart.", null);
            }

        }
    }
}
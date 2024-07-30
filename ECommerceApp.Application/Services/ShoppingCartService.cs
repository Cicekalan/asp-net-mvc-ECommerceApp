using AutoMapper;
using ECommerceApp.Application.DTOs;
using ECommerceApp.Application.Interfaces;
using ECommerceApp.Core;
using ECommerceApp.Core.Interfaces;
using ECommerceApp.Core.Models;

namespace ECommerceApp.Application.Services
{
    public class ShoppingCartService : IShoppingCartService
    {

        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public ShoppingCartService(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }


        public async Task<Result<CartItem>> AddItemToCartAsync(string customerId, CartItemDTO cartItemDTO)
        {
            var cartResult = await _manager.ShoppingCartRepository.GetCartByCustomerIdAsync(customerId);
            if (!cartResult.Success)
            {
                return new Result<CartItem>(false, "Shopping cart not found.", null);
            }
            cartItemDTO.ShoppingCartId = cartResult.Data!.ShoppingCartId;
            var cartItem = _mapper.Map<CartItem>(cartItemDTO);
            cartItem.ShoppingCartId = cartResult.Data!.ShoppingCartId;
            return await _manager.CartItemRepository.AddItemToCartAsync(cartItem);
        }

        public async Task<Result<ShoppingCart>> GetCartByCustomerIdAsync(string customerId)
        {
            return await _manager.ShoppingCartRepository.GetCartByCustomerIdAsync(customerId);
        }
        public async Task<Result<IEnumerable<CartItem>>> GetCartItemsAsync(string customerId)
        {
            var cartResult = await  GetCartByCustomerIdAsync(customerId);
            if (!cartResult.Success)
            {
                return new Result<IEnumerable<CartItem>>(false, "Shopping cart not found.", null);
            }
            var cartItemsResult = await _manager.CartItemRepository.GetCartItemsAsync(cartResult.Data!.ShoppingCartId, customerId);
            return cartItemsResult;
        }

        public async Task<int> GetCartItemsCountAsync(string customerId)
        {
            var cartResult = await GetCartItemsAsync(customerId);
            int count = 0;
            if (cartResult.Success)
            {
                foreach (var item in cartResult.Data!)
                {
                    count += item.Quantity;
                }
                return count;
            }
            return count;
        }

        public async Task<Result<CartItem>> RemoveAllItemFromCartAsync(string customerId, int productId)
        {
            var cartResult = await GetCartByCustomerIdAsync(customerId);
            if(!cartResult.Success)
            {
                return new Result<CartItem>(false, "Shopping cart not found.", null);
            }
            var cartItemsResult = await _manager.CartItemRepository.RemoveAllItemFromCartAsync(cartResult.Data!.ShoppingCartId, productId);
            return cartItemsResult;
        }

        public async Task<Result<CartItem>> RemoveItemFromCartAsync(string customerId, int productId)
        {
            var cartResult = await GetCartByCustomerIdAsync(customerId);
            if(!cartResult.Success)
            {
                return new Result<CartItem>(false, "Shopping cart not found.", null);
            }
            var cartItemsResult = await _manager.CartItemRepository.RemoveItemFromCartAsync(cartResult.Data!.ShoppingCartId, productId);
            return cartItemsResult;
        }


    }
}
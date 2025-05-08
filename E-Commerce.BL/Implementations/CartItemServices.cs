using E_Commerce.BL.Contracts.Repositories;
using E_Commerce.BL.Contracts.Services;
using E_Commerce.BL.Features.CartItem;
using E_Commerce.BL.Features.OrderDetail.DTOs;
using E_Commerce.Domain.Models;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BL.Implementations
{
    public class CartItemServices : AppService, ICartItemServices
    {
        private readonly ICartItemRepository _cartItemRepository;

        public CartItemServices(ICartItemRepository cartItemRepository)
        {
            _cartItemRepository = cartItemRepository;
        }

        public async Task<CartItemDTO> AddProductAsync(CartItemDTO CartItem)
        {

            var cartItem = new CartItem
            {
                UserID = CartItem.UserID,
                ProductID = CartItem.ProductID,
                Quantity=CartItem.Quantity,
                DateAdded=CartItem.DateAdded
            };

            var cart = await _cartItemRepository.AddAsync(cartItem);
            var cartitem = cartItem?.Adapt<CartItemDTO>();
            return cartitem;
        }

        public async Task<CartItemDTO> GetCartItemByIdAsync(int id)
        {
            var cart = await _cartItemRepository.GetByIdAsync(id);
            var cartitem = cart?.Adapt<CartItemDTO>();
            return cartitem;
        }

        public async Task<IEnumerable<CartItemDTO>> GetAllProductsAsync()
        {
            var cart = _cartItemRepository.GetAllAsync();
            var cartitem = cart?.Adapt<List<CartItemDTO>>();
            return cartitem;
        }

        public async Task<CartItemDTO> UpdateCartItemAsync(CartItem CartItem)
        {
            var cart = await _cartItemRepository.Update(CartItem);
            var cartitem = cart?.Adapt<CartItemDTO>();
            return cartitem;
        }
        public async Task<List<CartItem>> GetCartItemsByUserIdAsync(int userId)
        {
            return await _cartItemRepository.GetCartItemsByUserIdAsync(userId);
        }
        public async Task DeleteCArtItemAsync(int )
        {
            var cartItem = await _cartItemRepository.GetByIdAsync(Id);
            if (cartItem != null)
            {
                await _cartItemRepository.Delete(cartItem);
            }
        }

        public async Task ClearCartAsync(int userId)
        {
            // Get all cart items for the user
            var userCartItems = await _cartItemRepository.GetCartItemsByUserIdAsync(userId);

            if (userCartItems != null && userCartItems.Any())
            {
                foreach (var item in userCartItems)
                {
                    await _cartItemRepository.Delete(item);
                }
            }
        }



        public Task UpdateCartItemQuantityAsync(int cartItemId, int newQuantity)
        {
            throw new NotImplementedException();
        }
    }
}

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
        public async Task<List<CartItem>> GetCartItemsByUserIdAsync(int userId)
        {
            return await _cartItemRepository.GetAllAsync(ci => ci.UserID == userId);
        }

        public async Task ClearCartAsync(int userId)
        {
            var items = await _cartItemRepository.GetAllAsync(ci => ci.UserID == userId);
            foreach (var item in items)
            {
                await _cartItemRepository.Delete(item);
            }
            await _cartItemRepository.CommitAsync();
        }

        public async Task AddToCartAsync(CartItem item)
        {
            await _cartItemRepository.AddAsync(item);
            await _cartItemRepository.CommitAsync();
        }

        public async Task RemoveCartItemAsync(int cartItemId)
        {
            var item = await _cartItemRepository.GetByIdAsync(cartItemId);
            if (item != null)
            {
                await _cartItemRepository.Delete(item);
                await _cartItemRepository.CommitAsync();
            }
        }

    }
}

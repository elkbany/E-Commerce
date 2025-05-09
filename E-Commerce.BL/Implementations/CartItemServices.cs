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
using static E_Commerce.BL.Implementations.CartItemServices;

namespace E_Commerce.BL.Implementations
{
    public class CartItemServices : AppService, ICartItemServices
    {
        
            private readonly ICartItemRepository _cartRepo;
            private readonly IProductRepository _productRepo;
            private readonly IOrderServices _orderService;

            public CartItemServices(ICartItemRepository cartRepo,IProductRepository productRepo,IOrderServices orderService)
            {
                _cartRepo = cartRepo;
                _productRepo = productRepo;
                _orderService = orderService;
            }

            public async Task AddToCartAsync(int userId, int productId, int quantity)
            {
                var cartItem = await _cartRepo.FirstOrDefaultAsync(x => x.UserID == userId && x.ProductID == productId);

                if (cartItem != null)
                {
                    cartItem.Quantity += quantity;
                    await _cartRepo.Update(cartItem);
                }
                else
                {
                    cartItem = new CartItem
                    {
                        UserID = userId,
                        ProductID = productId,
                        Quantity = quantity
                    };
                    await _cartRepo.AddAsync(cartItem);
                }

                await _cartRepo.CommitAsync();
            }

            public async Task<List<CartItem>> GetCartItemsByUserIdAsync(int userId)
            {
                return await _cartRepo.GetAllAsync(x => x.UserID == userId, x => x.Product);
            }

            public async Task UpdateCartItemQuantityAsync(int cartItemId, int newQuantity)
            {
                var cartItem = await _cartRepo.GetByIdAsync(cartItemId);
                if (cartItem != null)
                {
                    cartItem.Quantity = newQuantity;
                    await _cartRepo.Update(cartItem);
                    await _cartRepo.CommitAsync();
                }
            }

            public async Task RemoveCartItemAsync(int cartItemId)
            {
                var cartItem = await _cartRepo.GetByIdAsync(cartItemId);
                if (cartItem != null)
                {
                    await _cartRepo.Delete(cartItem);
                    await _cartRepo.CommitAsync();
                }
            }

            public async Task SubmitCartAsync(int userId)
            {
                var items = await _cartRepo.GetAllAsync(x => x.UserID == userId, x => x.Product);
                if (!items.Any()) return;

                await _orderService.CreateOrderFromCartItemsAsync(userId, items);

                foreach (var item in items)
                    await _cartRepo.Delete(item);

                await _cartRepo.CommitAsync();
            }
        }
}

using E_Commerce.BL.Contracts.Repositories;
using E_Commerce.BL.Contracts.Services;
using E_Commerce.BL.Features.CartItem;
using E_Commerce.BL.Features.CartItem.DTO;
using E_Commerce.BL.Features.CartItem.Validators;
using E_Commerce.BL.Features.OrderDetail.DTOs;
using E_Commerce.Domain.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;
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
        public CartItemServices(ICartItemRepository cartRepo, IProductRepository productRepo, IOrderServices orderService)
        {
            _cartRepo = cartRepo;
            _productRepo = productRepo;
            _orderService = orderService;
        }

        public async Task<CartItemDTO> AddToCartAsync(AddCartItemDTO cartItemDto)
        {
            Console.WriteLine($"Adding to cart: ProductId={cartItemDto.ProductId}, UserId={cartItemDto.UserId}, Quantity={cartItemDto.Quantity}");
            await DoValidationAsync<AddCartItemDTOValidator, AddCartItemDTO>(cartItemDto);

            using var transaction = await _cartRepo.BeginTransactionAsync();
            try
            {
                var product = await _productRepo.GetByIdAsync(cartItemDto.ProductId, transaction);
                if (product == null)
                {
                    await transaction.RollbackAsync();
                    throw new Exception($"Failed to add product to cart. Product with ID {cartItemDto.ProductId} not found.");
                }
                if (product.UnitsInStock < cartItemDto.Quantity)
                {
                    await transaction.RollbackAsync();
                    throw new Exception($"Failed to add product to cart. Only {product.UnitsInStock} units available, but {cartItemDto.Quantity} requested.");
                }

                var cartItem = cartItemDto.Adapt<CartItem>();
                cartItem.DateAdded = DateTime.Now;

                var addedItem = await _cartRepo.AddAsync(cartItem, transaction);
                await _context.SaveChangesAsync(); // تأكيد الحفظ
                await _cartRepo.CommitAsync(transaction);

                var result = (await _cartRepo.FirstOrDefaultAsync(x => x.Id == addedItem.Id, x => x.Product)).Adapt<CartItemDTO>();
                await transaction.CommitAsync();
                return result;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                Console.WriteLine($"Error in AddToCartAsync: {ex.Message}");
                throw new Exception($"Failed to add product to cart. Error: {ex.Message}", ex);
            }
        }
        public async Task<IEnumerable<CartItemDTO>> GetCartItemsByUserIdAsync(int userId)
        {
            var cartItems = await _cartRepo.GetAllAsync(x => x.UserID == userId, x => x.Product);
            return cartItems.Adapt<List<CartItemDTO>>();
        }

        public async Task<CartItemDTO> UpdateProductQuantityAsync(int cartItemId, UpdateCartItemQuantityDTO quantityDto)
        {
           
            await DoValidationAsync<UpdateCartItemQuantityDTOValidator, UpdateCartItemQuantityDTO>(quantityDto);

            var cartItem = await _cartRepo.FirstOrDefaultAsync(x => x.Id == cartItemId, x => x.Product);
            if (cartItem == null)
                throw new Exception("Cart item not found.");
            if (cartItem.Product.UnitsInStock < quantityDto.Quantity)
                throw new Exception("Requested quantity exceeds available stock.");
           

            cartItem.Quantity = quantityDto.Quantity;
            await _cartRepo.Update(cartItem);
            await _cartRepo.CommitAsync();

            return cartItem.Adapt<CartItemDTO>();
        }

        public async Task DeleteFromCartAsync(int cartItemId)
        {
            var cartItem = await _cartRepo.FirstOrDefaultAsync(x => x.Id == cartItemId);
            if (cartItem == null)
                throw new Exception("Cart item not found.");

            await _cartRepo.Delete(cartItem);
            await _cartRepo.CommitAsync();
        }

        public async Task SubmitCartAsync(int userId)
        {
            var cartItems = await _cartRepo.GetAllAsync(x => x.UserID == userId, x => x.Product);
            if (!cartItems.Any())
                throw new Exception("Cart is empty.");

            await _orderService.CreateOrderFromCartItemsAsync(userId, cartItems);

            foreach (var item in cartItems)
                await _cartRepo.Delete(item);

            await _cartRepo.CommitAsync();
        }
    }
}

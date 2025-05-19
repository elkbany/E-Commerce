using E_Commerce.BL.Contracts.Repositories;
using E_Commerce.BL.Contracts.Services;
using E_Commerce.BL.Features.CartItem.DTO;
using E_Commerce.BL.Features.CartItem.Validators;
using E_Commerce.BL.Features.Order.DTOs;
using E_Commerce.Domain.Models;
using Mapster;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.BL.Implementations
{
    public class CartItemServices : AppService, ICartItemServices
    {
        private readonly ICartItemRepository cartItemRepository;
        private readonly IProductServices productServices;
        private readonly IOrderServices orderService;
        private readonly ILogger<CartItemServices> logger;

        public event EventHandler<int> CartUpdated;

        public CartItemServices(
            ICartItemRepository cartItemRepository,
            IProductServices productServices,
            IOrderServices orderService,
            ILogger<CartItemServices> logger)
        {
            this.cartItemRepository = cartItemRepository;
            this.productServices = productServices;
            this.orderService = orderService;
            this.logger = logger;
        }

        public async Task<CartItemDTO> AddToCartAsync(AddCartItemDTO cartItemDto)
        {
            await DoValidationAsync<AddCartItemDTOValidator, AddCartItemDTO>(cartItemDto);

            var product = await productServices.GetProductByIdAsync(cartItemDto.ProductId);
            if (product == null)
                throw new Exception($"Product with ID {cartItemDto.ProductId} not found.");

            if (product.UnitsInStock < cartItemDto.Quantity)
                throw new Exception($"Only {product.UnitsInStock} units available, but {cartItemDto.Quantity} requested.");

            var cartItem = new CartItem
            {
                UserID = cartItemDto.UserId,
                ProductID = cartItemDto.ProductId,
                Quantity = cartItemDto.Quantity,
                DateAdded = DateTime.Now
            };

            var addedItem = await cartItemRepository.AddAsync(cartItem);
            await cartItemRepository.CommitAsync(); // assuming the repository has this method

            if (addedItem != null)
            {
                var result = addedItem.Adapt<CartItemDTO>();
                CartUpdated?.Invoke(this, cartItemDto.UserId);
                return result;
            }

            throw new Exception("Failed to add item to cart.");
        }

        public async Task<IEnumerable<CartItemDTO>> GetCartItemsByUserIdAsync(int userId)
        {
            logger.LogInformation($"Fetching cart items for user {userId}");
            var cartItems = await cartItemRepository.GetAllAsync(x => x.UserID == userId, x => x.Product);
            return cartItems.Adapt<List<CartItemDTO>>();
        }

        public async Task<CartItemDTO> UpdateProductQuantityAsync(int cartItemId, UpdateCartItemQuantityDTO quantityDto)
        {
            await DoValidationAsync<UpdateCartItemQuantityDTOValidator, UpdateCartItemQuantityDTO>(quantityDto);

            var cartItem = await cartItemRepository.FirstOrDefaultAsync(x => x.Id == cartItemId, x => x.Product);
            if (cartItem == null)
                throw new Exception("Cart item not found.");

            if (cartItem.Product.UnitsInStock < quantityDto.Quantity)
                throw new Exception("Requested quantity exceeds available stock.");

            cartItem.Quantity = quantityDto.Quantity;
            await cartItemRepository.Update(cartItem);
            await cartItemRepository.CommitAsync();

            return cartItem.Adapt<CartItemDTO>();
        }

        public async Task DeleteFromCartAsync(int cartItemId)
        {
            var cartItem = await cartItemRepository.FirstOrDefaultAsync(x => x.Id == cartItemId);
            if (cartItem == null)
                throw new Exception("Cart item not found.");

            await cartItemRepository.Delete(cartItem);
            await cartItemRepository.CommitAsync();
        }

        public async Task SubmitCartAsync(int userId)
        {
            var cartItems = await cartItemRepository.GetAllAsync(x => x.UserID == userId, x => x.Product);
            if (!cartItems.Any())
                throw new Exception("Cart is empty.");

            await orderService.CreateOrderFromCartItemsAsync(userId, cartItems);

            foreach (var item in cartItems)
                await cartItemRepository.Delete(item);

            await cartItemRepository.CommitAsync();
        }
    }
}

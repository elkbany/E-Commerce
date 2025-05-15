using E_Commerce.BL.Contracts.Repositories;
using E_Commerce.BL.Contracts.Services;
using E_Commerce.BL.Features.CartItem.DTO;
using E_Commerce.BL.Features.CartItem.Validators;
using E_Commerce.BL.Features.Order.DTOs;
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
        private readonly ICartItemRepository _cartRepo;
        private readonly IProductServices productServices;
        //private readonly IProductRepository _productRepo;
        private readonly IOrderServices _orderService;

        public CartItemServices(ICartItemRepository cartRepo,IProductServices productServices, IOrderServices orderService)
        {
            _cartRepo = cartRepo;
            this.productServices = productServices;
           // _productRepo = productRepo;
            _orderService = orderService;
        }

        public async Task<CartItemDTO> AddToCartAsync(AddCartItemDTO cartItemDto)
        {
            await DoValidationAsync<AddCartItemDTOValidator, AddCartItemDTO>(cartItemDto);

            var product = await productServices.GetProductByIdAsync(cartItemDto.ProductId);
            if (product == null)
            {
                throw new Exception($"Product with ID {cartItemDto.ProductId} not found.");
            }
  
            if (product.UnitsInStock < cartItemDto.Quantity)
            {
                throw new Exception($"Only {product.UnitsInStock} units available, but {cartItemDto.Quantity} requested.");
            }

            var cartItem = new CartItem
            {
                UserID = cartItemDto.UserId,
                ProductID = cartItemDto.ProductId,
                Quantity = cartItemDto.Quantity,
              
            };
            cartItem.DateAdded = DateTime.Now;

            var addedItem = await _cartRepo.AddAsync(cartItem);
            if (addedItem != null)
            {
                product.UnitsInStock -= cartItemDto.Quantity;
                await productServices.UpdateProductAsync(cartItemDto.ProductId, product);

               
                var result = addedItem.Adapt<CartItemDTO>();
                return result;
            }
            else
            {
                throw new Exception("Failed to add item to cart.");
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
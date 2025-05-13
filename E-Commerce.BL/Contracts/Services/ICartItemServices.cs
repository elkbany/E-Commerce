using E_Commerce.BL.Features.CartItem;
using E_Commerce.BL.Features.CartItem.DTO;
using E_Commerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BL.Contracts.Services
{
     public interface ICartItemServices
    {
        //Task <CartItemDTO> AddToCartAsync(int clientId, int productId, int quantity);
        //Task<List<CartItemDTO>> GetCartItemsByUserIdAsync(int userId);
        //Task UpdateProductQuantityAsync(int productId, int newQuantity);
        //Task RemoveProductAsync(int productId);
        //Task SubmitCartAsync(int userId);
        Task<CartItemDTO> AddToCartAsync(AddCartItemDTO cartItemDto);
        Task<IEnumerable<CartItemDTO>> GetCartItemsByUserIdAsync(int userId);
        Task<CartItemDTO> UpdateProductQuantityAsync(int cartItemId, UpdateCartItemQuantityDTO quantityDto);
        Task DeleteFromCartAsync(int cartItemId);
        Task SubmitCartAsync(int userId);


    }


}

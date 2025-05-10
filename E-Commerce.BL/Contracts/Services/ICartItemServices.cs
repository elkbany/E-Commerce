using E_Commerce.BL.Features.CartItem;
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
        Task AddToCartAsync(int clientId, int productId, int quantity);
        Task<List<CartItem>> GetCartItemsByUserIdAsync(int userId);
        Task UpdateProductQuantityAsync(int productId, int newQuantity);
        Task RemoveProductAsync(int productId);
        Task SubmitCartAsync(int userId);
    }

}

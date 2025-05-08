using E_Commerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BL.Contracts.Repositories
{
    public interface ICartItemRepository: IGenericRepository<CartItem>

    {
        Task<List<CartItem>> GetCartItemsByUserIdAsync(int userId);
    }
}

using E_Commerce.BL.Contracts.Repositories;
using E_Commerce.DA.Context;
using E_Commerce.DA.Implementations.Base;
using E_Commerce.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DA.Implementations.Repositories
{
    public class CartItemRepository : GenericRepository<CartItem>, ICartItemRepository
    {
        protected readonly DBContext _context;
        private readonly DbSet<CartItem> _dbSet;
        public CartItemRepository(DBContext context) : base(context)
        {
            _context = context;
           
        }
        public async Task<List<CartItem>> GetCartItemsByUserIdAsync(int userId)
        {
            return await _context.CartItems
                .Where(c => c.UserID == userId)
                .Include(c => c.Product) // Optional
                .ToListAsync();
        }


    }
}

using E_Commerce.BL.Contracts.Repositories;
using E_Commerce.DA.Context;
using E_Commerce.DA.Implementations.Base;
using E_Commerce.Domain.Enums;
using E_Commerce.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DA.Implementations.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly DBContext _context;
        public OrderRepository(DBContext context) : base(context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Order>> GetOrdersByStatusAsync(OrderStatus status)
        {
            return await _context.Orders.Where(o => o.Status == status).ToListAsync();
        }

        Task IOrderRepository.GetOrdersByStatusAsync(OrderStatus status)
        {
            return GetOrdersByStatusAsync(status);
        }
    }
    
    
}

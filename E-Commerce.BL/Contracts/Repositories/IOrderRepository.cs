using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce.Domain.Enums;
using E_Commerce.Domain.Models;

namespace E_Commerce.BL.Contracts.Repositories
{
    public interface IOrderRepository : IGenericRepository<Order>
    {

        public Task<IEnumerable<Order>> GetOrdersByStatusAsync(OrderStatus status);
        Task<IEnumerable<Order>> GetOrdersByUserIdAsync(int userId);
    }


}

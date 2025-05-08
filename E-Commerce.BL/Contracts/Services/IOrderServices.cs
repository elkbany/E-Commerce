using E_Commerce.BL.Contracts.Repositories;
using E_Commerce.BL.Features.Order.DTOs;
using E_Commerce.BL.Features.Product.DTOs;
using E_Commerce.Domain.Enums;
using E_Commerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BL.Contracts.Services
{
    public interface IOrderServices
    {
        Task<OrderDTO> AddOrderAsync(OrderDTO orderDTO);
        Task<OrderDTO> UpdateOrderAsync(Order order);
        Task DeleteOrderAsync(int id);
        Task<IEnumerable<OrderDTO>> GetAllOrdersAsync();
        Task<OrderDTO> GetOrdertByIdAsync(int id);
        Task<IEnumerable<OrderDTO>> FilterOrdersByStatusAsync(OrderStatus status);
        Task<(bool Success, string Message, OrderDTO Data)> ApproveOrderAsync(int orderId);
        Task<(bool Success, string Message, OrderDTO Data)> DenyOrderAsync(int orderId);
    }
}

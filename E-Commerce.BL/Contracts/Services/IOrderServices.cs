using System.Collections.Generic;
using System.Threading.Tasks;
using E_Commerce.BL.Features.Order.DTOs;
using E_Commerce.BL.Features.OrderDetail.DTOs;
using E_Commerce.Domain.Enums;
using E_Commerce.Domain.Models;

namespace E_Commerce.BL.Contracts.Services
{
    public interface IOrderServices
    {
        Task<OrderDTO> AddOrderAsync(OrderDTO orderDTO);
        Task DeleteOrderAsync(int id);
        Task<IEnumerable<OrderDTO>> FilterOrdersByStatusAsync(OrderStatus status); 
        Task<IEnumerable<OrderDTO>> GetAllOrdersAsync();
        Task<OrderDTO> GetOrdertByIdAsync(int id);
        Task<OrderDTO> UpdateOrderAsync(Order order);
        Task<(bool Success, string Message, OrderDTO Data)> ApproveOrderAsync(int orderId);
        Task<(bool Success, string Message, OrderDTO Data)> DenyOrderAsync(int orderId);
        Task CreateOrderFromCartItemsAsync(int userId, List<CartItem> cartItems);
        Task<IEnumerable<OrderDTO>> GetOrdersByUserId(int userId);
    
    }
}
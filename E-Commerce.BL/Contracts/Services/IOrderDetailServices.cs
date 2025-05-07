using E_Commerce.BL.Features.Order.DTOs;
using E_Commerce.BL.Features.OrderDetail.DTOs;
using E_Commerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BL.Contracts.Services
{
    public interface IOrderDetailServices
    {
    
        Task<OrderDetailDTO> AddProductAsync(OrderDetailDTO orderDetail);
        Task<OrderDetailDTO> GetOrderDetailByIdAsync(int id);
        Task<IEnumerable<OrderDetailDTO>> GetAllProductsAsync();
        Task<OrderDetailDTO> UpdateProductAsync(OrderDetail orderDetail);
        Task DeleteOrderDetailedAsync(int id);

    }
}

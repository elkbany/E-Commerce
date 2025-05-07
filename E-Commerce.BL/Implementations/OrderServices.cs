using E_Commerce.BL.Contracts.Repositories;
using E_Commerce.BL.Contracts.Services;
using E_Commerce.BL.Features.Order.DTOs;
using E_Commerce.BL.Features.Product.DTOs;
using E_Commerce.Domain.Models;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BL.Implementations
{
    public class OrderServices : IOrderServices
    {
        private readonly  IOrderRepository _orderRepository;

        public OrderServices(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<OrderDTO> AddOrderAsync(OrderDTO orderDTO)
        {
            var order = new Order
            {
                UserID = orderDTO.UserID,
                OrderDate = orderDTO.OrderDate,
                TotalAmount = orderDTO.TotalAmount,
            };
            await _orderRepository.AddAsync(order);
            return orderDTO;
        }

        public async Task DeleteOrderAsync(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            if (order != null)
            {
                await _orderRepository.Delete(order);
            }
        }

        public async Task<IEnumerable<OrderDTO>> GetAllOrdersAsync()
        {
            var orders = await _orderRepository.GetAllAsync();
            var orderMap = orders.Adapt<List<OrderDTO>>();
            return orderMap;
        }

        public async Task<OrderDTO> GetOrdertByIdAsync(int id)
        {
            var order = _orderRepository.GetByIdAsync(id);

            var orderMap = order?.Adapt<OrderDTO>();
            return orderMap;
        }

        public async Task<OrderDTO> UpdateOrderAsync(Order order)
        {
            var ord = await _orderRepository.Update(order);
            var ordMapping = order?.Adapt<OrderDTO>();
            return ordMapping;
        }
    }
}

using E_Commerce.BL.Contracts.Repositories;
using E_Commerce.BL.Contracts.Services;
using E_Commerce.BL.Features.Order.DTOs;
using E_Commerce.BL.Features.Product.DTOs;
using E_Commerce.BL.Validators;
using E_Commerce.Domain.Enums;
using E_Commerce.Domain.Models;
using FluentValidation;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BL.Implementations
{
    public class OrderServices : AppService, IOrderServices
    {
        private readonly  IOrderRepository _orderRepository;
        private readonly IValidator<int> _orderValidator;
        private readonly IUserRepository _userRepository;

        public OrderServices(IOrderRepository orderRepository, IValidator<int> orderValidator)
        {
            _orderRepository = orderRepository;
            _orderValidator = orderValidator;
        }
        public async Task<OrderDTO> AddOrderAsync(OrderDTO orderDTO)
        {
            var order = new Order
            {
                UserID = orderDTO.UserID,
                OrderDate = orderDTO.OrderDate,
                TotalAmount = orderDTO.TotalAmount,
                Status = orderDTO.Status = OrderStatus.Pending
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

        public async Task<IEnumerable<OrderDTO>> FilterOrdersByStatusAsync(OrderStatus status)
        {
            var filteredOrders = await _orderRepository.GetOrdersByStatusAsync(status);
            return filteredOrders.Adapt<List<OrderDTO>>();
        }

        public async Task<IEnumerable<OrderDTO>> GetAllOrdersAsync()
        {
            var orders = await _orderRepository.GetAllAsync();
            var orderMap = orders.Adapt<List<OrderDTO>>();
            return orderMap;
        }

        public async Task<OrderDTO> GetOrdertByIdAsync(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);

            var orderMap = order?.Adapt<OrderDTO>();
            return orderMap;
        }

        public async Task<OrderDTO> UpdateOrderAsync(Order order)
        {
            var ord = await _orderRepository.Update(order);
            var ordMapping = ord?.Adapt<OrderDTO>();
            return ordMapping;
        }

        public async Task<(bool Success, string Message, OrderDTO Data)> ApproveOrderAsync(int orderId)
        {
            var validationResult = await _orderValidator.ValidateAsync(orderId);
            if (!validationResult.IsValid)
            {
                var errorMessage = string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage));
                return (false, errorMessage, null);
            }

            var order = await _orderRepository.GetByIdAsync(orderId);
            order.Status = OrderStatus.Approved;
            order.DateProcessed = DateTime.UtcNow;
            await _orderRepository.Update(order);
            await _orderRepository.CommitAsync();

            var orderDTO = order.Adapt<OrderDTO>();
            return (true, "Order approved successfully.", orderDTO);
        }

        public async Task<(bool Success, string Message, OrderDTO Data)> DenyOrderAsync(int orderId)
        {
            var validationResult = await _orderValidator.ValidateAsync(orderId);
            if (!validationResult.IsValid)
            {
                var errorMessage = string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage));
                return (false, errorMessage, null);
            }

            var order = await _orderRepository.GetByIdAsync(orderId);
            order.Status = OrderStatus.Denied;
            order.DateProcessed = DateTime.UtcNow;
            await _orderRepository.Update(order);
            await _orderRepository.CommitAsync();

            var orderDTO = order.Adapt<OrderDTO>();
            return (true, "Order denied successfully.", orderDTO);
        }


    }
}

using E_Commerce.BL.Contracts.Repositories;
using E_Commerce.BL.Contracts.Services;
using E_Commerce.BL.Features.Order.DTOs;
using E_Commerce.Domain.Enums;
using E_Commerce.Domain.Models;
using FluentValidation;
using Mapster;

namespace E_Commerce.BL.Implementations
{
    public class OrderServices : AppService, IOrderServices
    {
        private readonly  IOrderRepository _orderRepository;
        private readonly IValidator<int> _orderValidator;
        private readonly IUserRepository _userRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;

        public OrderServices(IOrderRepository orderRepository, IValidator<int> orderValidator, IOrderDetailRepository orderDetailRepository)
        {
            _orderRepository = orderRepository;
            _orderValidator = orderValidator;
            _orderDetailRepository = orderDetailRepository;
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

        public async Task CreateOrderFromCartItemsAsync(int userId, List<CartItem> cartItems)
        {
           
            var order = new Order
            {
                UserID = userId,
                OrderDate = DateTime.UtcNow,
                TotalAmount = cartItems.Sum(ci => ci.Product.Price * ci.Quantity), 
            };

            await _orderRepository.AddAsync(order);
            await _orderRepository.CommitAsync();

           
            foreach (var cartItem in cartItems)
            {
                var orderDetail = new OrderDetail
                {
                    OrderID = order.OrderID,
                    ProductID = cartItem.ProductID,
                    Quantity = cartItem.Quantity,
                 
                };
                await _orderDetailRepository.AddAsync(orderDetail);

            }

            await _orderRepository.CommitAsync();
        }
    }
}

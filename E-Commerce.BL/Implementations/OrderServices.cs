using E_Commerce.BL.Contracts.Repositories;
using E_Commerce.BL.Contracts.Services;
using E_Commerce.BL.Features.Order.DTOs;
using E_Commerce.Domain.Enums;
using E_Commerce.Domain.Models;
using FluentValidation;
using Mapster;
using System.Linq.Expressions;
using System.Security.Principal;

namespace E_Commerce.BL.Implementations
{
    public class OrderServices : AppService, IOrderServices
    {
        private readonly  IOrderRepository _orderRepository;
        private readonly IValidator<int> _orderValidator;
        private readonly IUserRepository _userRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IProductRepository _productRepository;

        public OrderServices(IOrderRepository orderRepository, IValidator<int> orderValidator, IOrderDetailRepository orderDetailRepository,IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _orderValidator = orderValidator;
            _orderDetailRepository = orderDetailRepository;
            _productRepository = productRepository;

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

            var order = await _orderRepository.FirstOrDefaultAsync(
                o => o.OrderID == orderId,
                o => o.OrderDetails);
            if (order == null)
                return (false, "Order not found.", null);

            if (order.Status != OrderStatus.Pending)
                return (false, "Only pending orders can be approved.", null);

            var orderDetails = await _orderDetailRepository.GetAllAsync(
                od => od.OrderID == orderId,
                od => od.Product);

           
            foreach (var detail in orderDetails)
            {
                var product = detail.Product;
                if (product.UnitsInStock < detail.Quantity)
                    return (false, $"Not enough stock for product {product.Name}.", null);

                product.UnitsInStock = product.UnitsInStock-detail.Quantity;
                await _productRepository.Update(product);
            }

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

            var order = await _orderRepository.FirstOrDefaultAsync(
                o => o.OrderID == orderId,
                o => o.OrderDetails);
            if (order == null)
                return (false, "Order not found.", null);

            if (order.Status != OrderStatus.Pending)
                return (false, "Only pending orders can be denied.", null);

            var orderDetails = await _orderDetailRepository.GetAllAsync(
                od => od.OrderID == orderId,
                od => od.Product);

            foreach (var detail in orderDetails)
            {
                var product = detail.Product;
                product.UnitsInStock = product.UnitsInStock+detail.Quantity;
                await _productRepository.Update(product);
            }

            order.Status = OrderStatus.Denied;
            order.DateProcessed = DateTime.UtcNow;
            await _orderRepository.Update(order);
            await _orderRepository.CommitAsync();

            var orderDTO = order.Adapt<OrderDTO>();
            return (true, "Order denied successfully.", orderDTO);
        }
        public async Task CreateOrderFromCartItemsAsync(int userId, List<CartItem> cartItems)
        {
          
            foreach (var cartItem in cartItems)
            {
                var product = await _productRepository.GetByIdAsync(cartItem.ProductID);
                if (product == null || product.UnitsInStock < cartItem.Quantity)
                {
                    throw new Exception($"Not enough stock for product ID {cartItem.ProductID}. Available: {product?.UnitsInStock ?? 0}, Requested: {cartItem.Quantity}");
                }
            }

            
            decimal totalAmount = 0;
            foreach (var cartItem in cartItems)
            {
                var product = await _productRepository.GetByIdAsync(cartItem.ProductID);
                totalAmount += product.Price * cartItem.Quantity;
            }

            var order = new Order
            {
                UserID = userId,
                OrderDate = DateTime.UtcNow,
                TotalAmount = totalAmount, 
                Status = OrderStatus.Pending
            };

            await _orderRepository.AddAsync(order);
            await _orderRepository.CommitAsync();

            foreach (var cartItem in cartItems)
            {
                var orderDetail = new OrderDetail
                {
                    OrderID = order.OrderID,
                    ProductID = cartItem.ProductID,
                    Quantity = cartItem.Quantity
                };
                await _orderDetailRepository.AddAsync(orderDetail);
            }

            await _orderRepository.CommitAsync();
        }
        public async Task<(bool Success, string Message, OrderDTO Data)> UpdateOrderStatusAsync(int orderId, OrderStatus newStatus)
        {
            var order = await _orderRepository.FirstOrDefaultAsync(o => o.OrderID == orderId);
            if (order == null)
                return (false, "Order not found.", null);

            order.Status = newStatus;
            await _orderRepository.Update(order);
            await _orderRepository.CommitAsync();

            var orderDTO = order.Adapt<OrderDTO>();
            return (true, "Order status updated successfully.", orderDTO);
        }

        public async Task<IEnumerable<OrderDTO>> GetOrdersByUserId(int userId)
        {
            var orders = await _orderRepository.GetOrdersByUserIdAsync(userId);
            return orders.Adapt<List<OrderDTO>>();
        }
        public async Task<IEnumerable<OrderDTO>> GetOrdersByUserIdAndStatusAsync(int userId, OrderStatus? status = null)
        {
            Expression<Func<Order, bool>> criteria = o => o.UserID == userId;
            if (status.HasValue)
                criteria = o => o.UserID == userId && o.Status == status.Value;

            var orders = await _orderRepository.GetAllAsync(
                criteria,
                o => o.User,
                o => o.OrderDetails);
            return orders.Adapt<List<OrderDTO>>();
        }
    }
}

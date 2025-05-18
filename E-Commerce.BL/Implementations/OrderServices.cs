using E_Commerce.BL.Contracts.Repositories;
using E_Commerce.BL.Contracts.Services;
using E_Commerce.BL.Features.Order.DTOs;
using E_Commerce.Domain.Enums;
using E_Commerce.Domain.Models;
using FluentValidation;
using Mapster;
using System.Linq.Expressions;

namespace E_Commerce.BL.Implementations
{
    public class OrderServices : AppService, IOrderServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<int> _orderValidator;

        public OrderServices(IUnitOfWork unitOfWork, IValidator<int> orderValidator)
        {
            _unitOfWork = unitOfWork;
            _orderValidator = orderValidator;
        }

        public async Task<OrderDTO> AddOrderAsync(OrderDTO orderDTO)
        {
            var order = new Order
            {
                UserID = orderDTO.UserID,
                OrderDate = orderDTO.OrderDate,
                TotalAmount = orderDTO.TotalAmount,
                Status = OrderStatus.Pending
            };
            await _unitOfWork.Orders.AddAsync(order);
            await _unitOfWork.CommitAsync();
            return orderDTO;
        }

        public async Task DeleteOrderAsync(int id)
        {
            var order = await _unitOfWork.Orders.GetByIdAsync(id);
            if (order != null)
            {
                await _unitOfWork.Orders.Delete(order);
                await _unitOfWork.CommitAsync();
            }
        }

        public async Task<IEnumerable<OrderDTO>> FilterOrdersByStatusAsync(OrderStatus status)
        {
            var filteredOrders = await _unitOfWork.Orders.GetOrdersByStatusAsync(status);
            return filteredOrders.Adapt<List<OrderDTO>>();
        }

        public async Task<IEnumerable<OrderDTO>> GetAllOrdersAsync()
        {
            var orders = await _unitOfWork.Orders.GetAllAsync();
            return orders.Adapt<List<OrderDTO>>();
        }

        public async Task<OrderDTO> GetOrdertByIdAsync(int id)
        {
            var order = await _unitOfWork.Orders.GetByIdAsync(id);
            return order?.Adapt<OrderDTO>();
        }

        public async Task<OrderDTO> UpdateOrderAsync(Order order)
        {
            var updatedOrder = await _unitOfWork.Orders.Update(order);
            await _unitOfWork.CommitAsync();
            return updatedOrder?.Adapt<OrderDTO>();
        }

        public async Task<(bool Success, string Message, OrderDTO Data)> ApproveOrderAsync(int orderId)
        {
            var validationResult = await _orderValidator.ValidateAsync(orderId);
            if (!validationResult.IsValid)
            {
                var errorMessage = string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage));
                return (false, errorMessage, null);
            }

            var order = await _unitOfWork.Orders.FirstOrDefaultAsync(
                o => o.OrderID == orderId,
                o => o.OrderDetails);
            if (order == null)
                return (false, "Order not found.", null);

            if (order.Status != OrderStatus.Pending)
                return (false, "Only pending orders can be approved.", null);

            var orderDetails = await _unitOfWork.OrderDetails.GetAllAsync(
                od => od.OrderID == orderId,
                od => od.Product);

            foreach (var detail in orderDetails)
            {
                var product = detail.Product;
                if (product.UnitsInStock < detail.Quantity)
                    return (false, $"Not enough stock for product {product.Name}.", null);

                product.UnitsInStock -= detail.Quantity;
                await _unitOfWork.Products.Update(product);
            }

            order.Status = OrderStatus.Approved;
            order.DateProcessed = DateTime.UtcNow;
            await _unitOfWork.Orders.Update(order);
            await _unitOfWork.CommitAsync();

            return (true, "Order approved successfully.", order.Adapt<OrderDTO>());
        }

        public async Task<(bool Success, string Message, OrderDTO Data)> DenyOrderAsync(int orderId)
        {
            var validationResult = await _orderValidator.ValidateAsync(orderId);
            if (!validationResult.IsValid)
            {
                var errorMessage = string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage));
                return (false, errorMessage, null);
            }

            var order = await _unitOfWork.Orders.FirstOrDefaultAsync(
                o => o.OrderID == orderId,
                o => o.OrderDetails);
            if (order == null)
                return (false, "Order not found.", null);

            if (order.Status != OrderStatus.Pending)
                return (false, "Only pending orders can be denied.", null);

            var orderDetails = await _unitOfWork.OrderDetails.GetAllAsync(
                od => od.OrderID == orderId,
                od => od.Product);

            foreach (var detail in orderDetails)
            {
                var product = detail.Product;
                product.UnitsInStock += detail.Quantity;
                await _unitOfWork.Products.Update(product);
            }

            order.Status = OrderStatus.Denied;
            order.DateProcessed = DateTime.UtcNow;
            await _unitOfWork.Orders.Update(order);
            await _unitOfWork.CommitAsync();

            return (true, "Order denied successfully.", order.Adapt<OrderDTO>());
        }

        public async Task CreateOrderFromCartItemsAsync(int userId, List<CartItem> cartItems)
        {
            foreach (var cartItem in cartItems)
            {
                var product = await _unitOfWork.Products.GetByIdAsync(cartItem.ProductID);
                if (product == null || product.UnitsInStock < cartItem.Quantity)
                {
                    throw new Exception($"Not enough stock for product ID {cartItem.ProductID}. Available: {product?.UnitsInStock ?? 0}, Requested: {cartItem.Quantity}");
                }
            }

            decimal totalAmount = 0;
            foreach (var cartItem in cartItems)
            {
                var product = await _unitOfWork.Products.GetByIdAsync(cartItem.ProductID);
                totalAmount += product.Price * cartItem.Quantity;
            }

            var order = new Order
            {
                UserID = userId,
                OrderDate = DateTime.UtcNow,
                TotalAmount = totalAmount,
                Status = OrderStatus.Pending
            };

            await _unitOfWork.Orders.AddAsync(order);

            foreach (var cartItem in cartItems)
            {
                var orderDetail = new OrderDetail
                {
                    OrderID = order.OrderID,
                    ProductID = cartItem.ProductID,
                    Quantity = cartItem.Quantity
                };
                await _unitOfWork.OrderDetails.AddAsync(orderDetail);
            }

            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<OrderDTO>> GetOrdersByUserId(int userId)
        {
            var orders = await _unitOfWork.Orders.GetOrdersByUserIdAsync(userId);
            return orders.Adapt<List<OrderDTO>>();
        }

        public async Task<IEnumerable<OrderDTO>> GetOrdersByUserIdAndStatusAsync(int userId, OrderStatus? status = null)
        {
            Expression<Func<Order, bool>> criteria = o => o.UserID == userId;
            if (status.HasValue)
                criteria = o => o.UserID == userId && o.Status == status.Value;

            var orders = await _unitOfWork.Orders.GetAllAsync(
                criteria,
                o => o.User,
                o => o.OrderDetails);
            return orders.Adapt<List<OrderDTO>>();
        }
    }
}

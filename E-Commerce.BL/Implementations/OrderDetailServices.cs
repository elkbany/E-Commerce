using E_Commerce.BL.Contracts.Repositories;
using E_Commerce.BL.Contracts.Services;
using E_Commerce.BL.Features.OrderDetail.DTOs;
using E_Commerce.Domain.Models;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.BL.Implementations
{
    public class OrderDetailServices : AppService, IOrderDetailServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderDetailServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OrderDetailDTO> AddProductAsync(OrderDetailDTO orderDetail)
        {
            var orderDetailEntity = new OrderDetail
            {
                OrderID = orderDetail.OrderId,
                ProductID = orderDetail.ProductId,
                Quantity = orderDetail.Quantity
            };

            var added = await _unitOfWork.OrderDetails.AddAsync(orderDetailEntity);
            await _unitOfWork.CommitAsync();

            return added.Adapt<OrderDetailDTO>();
        }

        public async Task<OrderDetailDTO> GetOrderDetailByIdAsync(int id)
        {
            var entity = await _unitOfWork.OrderDetails.GetByIdAsync(id);
            return entity?.Adapt<OrderDetailDTO>();
        }

        public async Task<IEnumerable<OrderDetailDTO>> GetAllProductsAsync()
        {
            var entities = await _unitOfWork.OrderDetails.GetAllAsync();
            return entities.Adapt<List<OrderDetailDTO>>();
        }

        public async Task<OrderDetailDTO> UpdateProductAsync(OrderDetail orderDetail)
        {
            var updated = await _unitOfWork.OrderDetails.Update(orderDetail);
            await _unitOfWork.CommitAsync();

            return updated?.Adapt<OrderDetailDTO>();
        }

        public async Task<List<OrderDetailDTO>> GetOrderDetailsByOrderIdAsync(int orderId)
        {
            var orderDetails = await _unitOfWork.OrderDetails.GetAllAsync(
                criteria: od => od.OrderID == orderId,
                includes: od => od.Product
            );

            var mapped = orderDetails.Select(od => new OrderDetailDTO
            {
                Id = od.Id,
                OrderId = od.OrderID,
                ProductId = od.ProductID,
                ProductName = od.Product?.Name,
                Quantity = od.Quantity,
                Price = od.Product?.Price ?? 0
            }).ToList();

            return mapped;
        }

        public async Task DeleteOrderDetailedAsync(int id)
        {
            var entity = await _unitOfWork.OrderDetails.GetByIdAsync(id);
            if (entity != null)
            {
                await _unitOfWork.OrderDetails.Delete(entity);
                await _unitOfWork.CommitAsync();
            }
        }
    }
}

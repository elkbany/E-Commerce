using E_Commerce.BL.Contracts.Repositories;
using E_Commerce.BL.Contracts.Services;
using E_Commerce.BL.Features.OrderDetail.DTOs;
using E_Commerce.BL.Features.Product.Validators;
using E_Commerce.Domain.Models;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BL.Implementations
{
   public class OrderDetailServices :AppService, IOrderDetailServices
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
         
        public OrderDetailServices (IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        public async Task<OrderDetailDTO> AddProductAsync(OrderDetailDTO orderDetail)
        {
          
            var OrderDetail = new OrderDetail
            {
              OrderID= orderDetail.OrderId,
              ProductID =orderDetail.ProductId,
              Quantity=orderDetail.Quantity
            };
            var ordDet = await _orderDetailRepository.AddAsync(OrderDetail);
            var orderDetailMap = OrderDetail?.Adapt<OrderDetailDTO>();
            return orderDetailMap;
        }

        public async Task<OrderDetailDTO> GetOrderDetailByIdAsync(int id)
        {
            var ordDet = await _orderDetailRepository.GetByIdAsync(id);
            var orderDetailMap = ordDet?.Adapt<OrderDetailDTO>();
            return orderDetailMap;
        }

        public async Task<IEnumerable<OrderDetailDTO>> GetAllProductsAsync()
        {
             var orderdetail = _orderDetailRepository.GetAllAsync();
            var orderDetailMap = orderdetail.Adapt<List<OrderDetailDTO>>();
            return orderDetailMap;
        }

        public async Task<OrderDetailDTO> UpdateProductAsync(OrderDetail orderDetail)
        {
            var orderdetail = await _orderDetailRepository.Update(orderDetail);
            var orderDetailMap = orderdetail?.Adapt<OrderDetailDTO>();
            return orderDetailMap;
        }
        public async Task<List<OrderDetailDTO>> GetOrderDetailsByOrderIdAsync(int orderId)
        {
           
                
                var orderDetails = await _orderDetailRepository.GetAllAsync(
                    criteria: od => od.OrderID == orderId,
                    includes: od => od.Product
                );

               
                var orderDetailDTOs = orderDetails.Select(od => new OrderDetailDTO
                {
                    Id = od.Id,
                    OrderId = od.OrderID,
                    ProductId = od.ProductID,
                    ProductName = od.Product.Name, 
                    Quantity = od.Quantity,
                    Price = od.Product.Price 
                }).ToList();

                return orderDetailDTOs;
            
        }
        public async Task DeleteOrderDetailedAsync(int id)
        {
            var orderdetail = await _orderDetailRepository.GetByIdAsync(id);
            if (orderdetail != null)
            {
                await _orderDetailRepository.Delete(orderdetail);
            }
        }
    }
}

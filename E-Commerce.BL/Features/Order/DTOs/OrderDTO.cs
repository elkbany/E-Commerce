using E_Commerce.BL.Features.OrderDetail.DTOs;
using E_Commerce.Domain.Enums;
using E_Commerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BL.Features.Order.DTOs
{
    public class OrderDTO
    {
        public int OrderID { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }
        public DateTime OrderDate { get; set; }

        public decimal TotalAmount { get; set; }

        public OrderStatus Status { get; set; } = OrderStatus.Pending;

        public DateTime? DateProcessed { get; set; }

        public List<OrderDetailDTO> OrderDetails { get; set; }
    }
}
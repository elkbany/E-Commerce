using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BL.Features.OrderDetail.DTOs
{
    public class OrderDetailDTO
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } // To display the product name
        public int Quantity { get; set; }
        public decimal Price { get; set; } // Product price at the time of the order
        public decimal TotalPrice => Quantity * Price; // Calculated total price

    }
}

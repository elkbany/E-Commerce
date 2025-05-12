using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BL.Features.CartItem.DTO
{
    public class CartItemDTO
    {
        public int Id { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice => ProductPrice * Quantity;
    }
    
}

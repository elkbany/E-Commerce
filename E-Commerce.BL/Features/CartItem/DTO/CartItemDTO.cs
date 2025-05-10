using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BL.Features.CartItem.DTO
{
   public class CartItemDTO
    {
        public int UserID { get; set; }

        public int ProductID { get; set; }
        public string Product_Name { get; set; }

        public int Preoduct_Price { get; set; }
        public int Quantity { get; set; }
        public int Total_Price { get; set; }
        public DateTime DateAdded { get; set; }

    }
}

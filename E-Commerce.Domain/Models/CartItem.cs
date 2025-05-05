using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Models
{
    public class CartItem
    {
        public int Id  { get; set; }  

        public int UserID { get; set; }  

        public int  ProductID { get; set; }  

        public int Quantity { get; set; }

        public DateTime DateAdded { get; set; }

        
        public CartItem()
        {
           
            DateAdded = DateTime.UtcNow;
        }
    }
}

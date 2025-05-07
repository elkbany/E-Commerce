using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Models
{
    public class CartItem
    {
        public int Id  { get; set; }
        [ForeignKey("User")]
        public int UserID { get; set; }
        [ForeignKey("Product")]
        public int  ProductID { get; set; }  

        public int Quantity { get; set; }

        public DateTime DateAdded { get; set; }
        public Product Product { get; set; }
        public User User { get; set; }


        
        public CartItem()
        {
           
            DateAdded = DateTime.UtcNow;
        }
    }
}

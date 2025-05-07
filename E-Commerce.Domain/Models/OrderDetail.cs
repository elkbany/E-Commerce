using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Models
{
    public class OrderDetail
    {
        public int Id  { get; set; }  

        [ForeignKey("Order")]
        public int  OrderID { get; set; }  

        public Order order { get; set; }
        [ForeignKey("Product")]

        public int  ProductID { get; set; } 

        public Product product { get; set; }
        public int Quantity { get; set; }

       
    }
}

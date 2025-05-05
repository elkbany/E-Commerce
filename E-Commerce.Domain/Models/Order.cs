using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Models
{
    public enum OrderStatus
    {
        Pending,
        Approved,
        Denied,
        Shipped
    }

    public class Order
    {
        public int OrderID { get; set; }  

        public int UserID { get; set; } 

        public DateTime OrderDate { get; set; }

        public decimal TotalAmount { get; set; }

        public OrderStatus Status { get; set; } = OrderStatus.Pending;

        public DateTime? DateProcessed { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
        public Order()
        {
          
            OrderDate = DateTime.UtcNow;
        }
    }
}

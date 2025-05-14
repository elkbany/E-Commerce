using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce.Domain.Models
{
    public class Product
    {

       
            public int Id  { get; set; }  
            public string Name { get; set; }

            public string Description { get; set; }

            public decimal Price { get; set; }

            public int UnitsInStock { get; set; }
             [ForeignKey("Category")]
            public int? CategoryID { get; set; }
            public Category? Category { get; set; }
            public ICollection<CartItem> CartItems { get; set; }
            public ICollection<OrderDetail> OrderDetails { get; set; }

    }
}


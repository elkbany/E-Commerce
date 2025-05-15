using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BL.Features.Product.DTOs
{
   public class AddProductDTO
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int UnitsInStock { get; set; }
        public string Category { get; set; }
    }
}

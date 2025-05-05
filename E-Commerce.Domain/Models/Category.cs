using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Models
{
  
        
        public class Category
        {
            public int Id { get; set; }  

            public string Name { get; set; }

            public string? Description { get; set; } 
           public ICollection<Product> products { get; set; }

           
            
        }
    }



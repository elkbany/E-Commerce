using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce.Domain.Enums;

namespace E_Commerce.Domain.Models
{ 
   public class User
    {
        
            public int Id  { get; set; }  
            public string Username { get; set; }

            public string PasswordHash { get; set; } 

            public string Email { get; set; }

            public string FirstName { get; set; }

            public string LastName { get; set; }

            public UserStatus status { get; set; }

            public bool IsActive { get; set; } = true;

            public DateTime DateCreated { get; set; }

            public DateTime? LastLoginDate { get; set; }
            public ICollection<CartItem> CartItem { get; set; }
            public ICollection<Order> Order { get; set; }




            public User()
            {
               
                DateCreated = DateTime.UtcNow;
            }
        
    }
}

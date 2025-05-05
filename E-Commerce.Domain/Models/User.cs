using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Models
{
    public enum UserRole
    {
        Client,
        Admin
    }
    class User
    {
        
            public int Id  { get; set; }  
            public string Username { get; set; }

            public string PasswordHash { get; set; } 

            public string Email { get; set; }

            public string FirstName { get; set; }

            public string LastName { get; set; }

            public UserRole Role { get; set; }

            public bool IsActive { get; set; } = true;

            public DateTime DateCreated { get; set; }

            public DateTime? LastLoginDate { get; set; }
            public ICollection<CartItem> CartItem { get; set; }




            public User()
            {
               
                DateCreated = DateTime.UtcNow;
            }
        
    }
}

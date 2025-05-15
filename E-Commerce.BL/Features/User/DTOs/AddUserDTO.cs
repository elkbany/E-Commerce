using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce.Domain.Enums;

namespace E_Commerce.BL.Features.User.DTOs
{
    public class AddUserDTO
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string status { get; set; }
    }
}

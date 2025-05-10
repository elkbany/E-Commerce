using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BL.Features.User.DTOs
{
    public class LoginUserDto
    {
        public string UsernameOrEmail { get; set; }
        public string Password { get; set; }
    }
}

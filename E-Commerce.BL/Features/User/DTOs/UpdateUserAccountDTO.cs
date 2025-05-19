using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce.Domain.Enums;

namespace E_Commerce.BL.Features.User.DTOs
{
    public class UpdateUserAccountDTO
    {
      

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        public bool ActiveOrNot {  get; set; }
        public UserStatus Role {  get; set; }
    }
}

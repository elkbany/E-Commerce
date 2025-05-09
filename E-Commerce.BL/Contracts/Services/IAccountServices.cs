using E_Commerce.BL.Features.User.DTOs;
using E_Commerce.BL.Features.User.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BL.Contracts.Services
{
   public interface IAccountServices
    {
        Task<bool> RegisterUser(RegisterUserDto registerUserDto);
        Task<bool> LoginUserAsync(LoginUserDto loginUserDto);
        Task<bool> LogoutUserAsync(string usernameOrEmail);
        Task<bool> UpdateUserAsync(UpdateUserDto dto);
    }
}

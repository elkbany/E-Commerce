using E_Commerce.BL.Contracts.Repositories;
using E_Commerce.BL.Contracts.Services;
using E_Commerce.BL.Features.User.DTOs;
using E_Commerce.BL.Features.User.Validators;
using E_Commerce.Domain.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BL.Implementations
{
    public class AccountServices : AppService, IAccountServices
    {
        private readonly IUserRepository userRepository;

        public AccountServices(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public async Task<bool> RegisterUser(RegisterUserDto registerUserDto)
        {
           await DoValidationAsync<RegisterUserDtoValidator, RegisterUserDto>(registerUserDto);
            var hasher = new PasswordHasher<User>();
            var user = new User
           {
               FirstName = registerUserDto.FirstName,
               LastName = registerUserDto.LastName,
               Username = registerUserDto.Username,
               Email = registerUserDto.Email,
                DateCreated = DateTime.UtcNow,
                //IsActive = true,
                //status = Domain.Enums.UserStatus.Client,
                // IsSignedInNow = false,
                // LastLoginDate = null,
                // PasswordHash = registerUserDto.Password,

            };
            user.PasswordHash = hasher.HashPassword(user, registerUserDto.Password);
            var userReg = await userRepository.AddAsync(user);
           return userReg != null;
        }
        public async Task<bool> LoginUserAsync(string usernameOrEmail, string password)
        {
            
            var user =  await userRepository.FirstOrDefaultAsync(u => u.Username == usernameOrEmail || u.Email == usernameOrEmail);
           
            if (user == null)
                return false;

        
            var hasher = new PasswordHasher<User>();
            var result = hasher.VerifyHashedPassword(user, user.PasswordHash, password);

            return result == Microsoft.AspNetCore.Identity.PasswordVerificationResult.Success;
        }
     

    }
}

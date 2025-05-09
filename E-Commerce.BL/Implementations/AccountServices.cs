using E_Commerce.BL.Contracts.Repositories;
using E_Commerce.BL.Contracts.Services;
using E_Commerce.BL.Features.User.DTOs;
using E_Commerce.BL.Features.User.Validators;
using E_Commerce.Domain.Enums;
using E_Commerce.Domain.Models;
using Microsoft.AspNetCore.Identity;
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
            await DoValidationAsync<RegisterUserDtoValidator, RegisterUserDto>(registerUserDto, userRepository); // مرر userRepository
            var hasher = new PasswordHasher<User>();
            var user = new User
            {
                FirstName = registerUserDto.FirstName,
                LastName = registerUserDto.LastName,
                Username = registerUserDto.Username,
                Email = registerUserDto.Email,
                //DateCreated = DateTime.UtcNow,
                //IsActive = true, // افتراضي
                //status = UserStatus.Client, // افتراضي
                //IsSignedInNow = false,
                //LastLoginDate = null
            };
            user.PasswordHash = hasher.HashPassword(user, registerUserDto.Password);
            var userReg = await userRepository.AddAsync(user);
            await userRepository.CommitAsync();
            return userReg != null;
        }

        public async Task<bool> LoginUserAsync(string usernameOrEmail, string password)
        {
            var user = await userRepository.FirstOrDefaultAsync(u => u.Username == usernameOrEmail || u.Email == usernameOrEmail);
            if (user == null || !user.IsActive)
                return false;

            var hasher = new PasswordHasher<User>();
            var result = hasher.VerifyHashedPassword(user, user.PasswordHash, password);
            if (result == PasswordVerificationResult.Success)
            {
                user.IsSignedInNow = true;
                user.LastLoginDate = DateTime.UtcNow;
                await userRepository.Update(user);
                await userRepository.CommitAsync();
            }
            return result == PasswordVerificationResult.Success;
        }

        public async Task<bool> LogoutUserAsync(string usernameOrEmail)
        {
            var user = await userRepository.FirstOrDefaultAsync(u => u.Username == usernameOrEmail || u.Email == usernameOrEmail);
            if (user == null || !user.IsSignedInNow)
                return false;

            user.IsSignedInNow = false;
            user.LastLoginDate = DateTime.UtcNow;
            var result = await userRepository.Update(user);
            await userRepository.CommitAsync();
            return result != null;
        }

        public async Task<bool> UpdateUserAsync(UpdateUserDto dto)
        {
            var user = await userRepository.FirstOrDefaultAsync(u => u.Id == dto.Id);
            if (user == null || !user.IsSignedInNow)
                return false;

            user.FirstName = dto.FirstName;
            user.LastName = dto.LastName;
            user.DateUpdated = DateTime.UtcNow;

            if (!string.IsNullOrWhiteSpace(dto.Password))
            {
                var hasher = new PasswordHasher<User>();
                user.PasswordHash = hasher.HashPassword(user, dto.Password);
            }

            var updated = await userRepository.Update(user);
            await userRepository.CommitAsync();
            return updated != null;
        }
    }
}
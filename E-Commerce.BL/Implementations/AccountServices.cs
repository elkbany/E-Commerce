using E_Commerce.BL.Contracts.Repositories;
using E_Commerce.BL.Contracts.Services;
using E_Commerce.BL.Features.User.DTOs;
using E_Commerce.BL.Features.User.Validators;
using E_Commerce.Domain.Enums;
using E_Commerce.Domain.Models;
using Mapster;
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
            await DoValidationAsync<RegisterUserDtoValidator, RegisterUserDto>(registerUserDto, userRepository);
            var hasher = new PasswordHasher<User>();
            var user = new User
            {
                FirstName = registerUserDto.FirstName,
                LastName = registerUserDto.LastName,
                Username = registerUserDto.Username,
                Email = registerUserDto.Email,
                Status = UserStatus.Client,
                IsActive = true,
                IsSignedInNow = false
            };
            user.PasswordHash = hasher.HashPassword(user, registerUserDto.Password);
            var userReg = await userRepository.AddAsync(user);
            await userRepository.CommitAsync();
            return userReg != null;
        }

        public async Task<bool> LoginUserAsync(LoginUserDto loginUserDto)
        {
            await DoValidationAsync<LoginUserDtoValidator, LoginUserDto>(loginUserDto);
            var user = await userRepository.FirstOrDefaultAsync(u => u.Username == loginUserDto.UsernameOrEmail || u.Email == loginUserDto.UsernameOrEmail);
            if (user == null || !user.IsActive)
                return false;

            var hasher = new PasswordHasher<User>();
            var result = hasher.VerifyHashedPassword(user, user.PasswordHash, loginUserDto.Password);

            if (result == PasswordVerificationResult.Success)
            {
                user.IsSignedInNow = true;
                user.LastLoginDate = DateTime.UtcNow;
                await userRepository.Update(user);
                await userRepository.CommitAsync();
                return true;
            }
            return false;
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

        public async Task<bool> UpdateUserAccount(UpdateUserAccountDTO dto, int userId)
        {
            try
            {
                await DoValidationAsync<UpdateUserAccountDTOValidator, UpdateUserAccountDTO>(dto);

                var user = await userRepository.FirstOrDefaultAsync(u => u.Id == userId);
                if (user == null || !user.IsSignedInNow)
                    return false;

                var oldDateUpdated = user.DateUpdated;

                user.FirstName = dto.FirstName;
                user.LastName = dto.LastName;
                user.Email = dto.Email;
                user.DateUpdated = DateTime.UtcNow;

                await userRepository.Update(user);
                await userRepository.CommitAsync();

                var updatedUser = await userRepository.GetByIdAsync(userId);
                if (updatedUser != null &&
                    (updatedUser.FirstName == dto.FirstName || updatedUser.LastName == dto.LastName || updatedUser.Email == dto.Email) &&
                    updatedUser.DateUpdated > oldDateUpdated)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error in UpdateUserAccount: {ex.Message}");
                if (ex.InnerException != null)
                {
                    System.Diagnostics.Debug.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                }
                throw; 
            }
        }

        public async Task<bool> UpdateUserAsync(UpdateUserDto dto)
        {
            try
            {
                var user = await userRepository.FirstOrDefaultAsync(u => u.Id == dto.Id);
                if (user == null || !user.IsSignedInNow)
                    return false;

                var oldDateUpdated = user.DateUpdated;
                string newPassword = dto.Password; 

                
                if (!string.IsNullOrWhiteSpace(dto.FirstName)) user.FirstName = dto.FirstName;
                if (!string.IsNullOrWhiteSpace(dto.LastName)) user.LastName = dto.LastName;

                
                bool isPasswordUpdated = false;
                if (!string.IsNullOrWhiteSpace(dto.Password))
                {
                    var hasher = new PasswordHasher<User>();
                    user.PasswordHash = hasher.HashPassword(user, dto.Password);
                    isPasswordUpdated = true;
                }

                user.DateUpdated = DateTime.UtcNow;

                await userRepository.Update(user);
                await userRepository.CommitAsync();

                
                var updatedUser = await userRepository.GetByIdAsync(dto.Id);
                if (updatedUser != null)
                {
                   
                    bool isDataUpdated = true;
                    if (!string.IsNullOrWhiteSpace(dto.FirstName) && updatedUser.FirstName != dto.FirstName) isDataUpdated = false;
                    if (!string.IsNullOrWhiteSpace(dto.LastName) && updatedUser.LastName != dto.LastName) isDataUpdated = false;

                    
                    bool isPasswordVerified = isPasswordUpdated ? await VerifyPasswordAsync(dto.Id, newPassword) : true;

                   
                    bool isDateUpdated = updatedUser.DateUpdated > oldDateUpdated;

                    
                    return (isDataUpdated || isPasswordVerified) && isDateUpdated;
                }
                return false;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error in UpdateUserAsync: {ex.Message}");
                if (ex.InnerException != null)
                {
                    System.Diagnostics.Debug.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                }
                throw;
            }
        }

        public async Task<UserIformationDTO> ViewProfile(int id)
        {
            var user = await userRepository.GetByIdAsync(id);
            return user.Adapt<UserIformationDTO>();
        }

        public async Task<int> GetUserIdByUsernameOrEmailAsync(string usernameOrEmail)
        {
            var user = await userRepository.FirstOrDefaultAsync(u => u.Username == usernameOrEmail || u.Email == usernameOrEmail);
            return user?.Id ?? -1;
        }

        public async Task<UserStatus> GetUserStatusAsync(int userId)
        {
            var user = await userRepository.GetByIdAsync(userId);
            return user?.Status ?? UserStatus.Client;
        }

        public async Task<bool> VerifyPasswordAsync(int userId, string password)
        {
            var user = await userRepository.GetByIdAsync(userId);
            if (user == null) return false;
            var hasher = new PasswordHasher<User>();
            return hasher.VerifyHashedPassword(user, user.PasswordHash, password) == PasswordVerificationResult.Success;
        }
    }
}
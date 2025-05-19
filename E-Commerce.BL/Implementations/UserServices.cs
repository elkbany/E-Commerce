using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_Commerce.BL.Contracts.Repositories;
using E_Commerce.BL.Contracts.Services;
using E_Commerce.BL.Features.User.DTOs;
using E_Commerce.BL.Features.User.Validators;
using E_Commerce.Domain.Enums;
using E_Commerce.Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Identity;

namespace E_Commerce.BL.Implementations
{
    public class UserServices : AppService, IUserServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<(UserDTO User, bool IsActive)> AddUserAsync(UserDTO user)
        {
            await DoValidationAsync<UserDTOValidator, UserDTO>(user, _unitOfWork.Users);

            var hasher = new PasswordHasher<User>();
            var newUser = new User
            {
                Username = user.Username,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Status = user.status // Note: The DTO uses 'status' (lowercase), but should be 'Status'
            };
            newUser.IsActive = true;
            newUser.PasswordHash = hasher.HashPassword(newUser, user.Password);

            await _unitOfWork.Users.AddAsync(newUser);
            await _unitOfWork.CommitAsync(); // Commit via Unit of Work

            return (newUser?.Adapt<UserDTO>(), newUser.IsActive);
        }

        public async Task<AddUserDTO> AddUserByAdminAsync(AddUserDTO user)
        {
            var hasher = new PasswordHasher<User>();
            var newUser = new User
            {
                Username = user.Username,
                Email = user.Email,
                Status = (UserStatus)Enum.Parse(typeof(UserStatus), user.status)
            };
            newUser.PasswordHash = hasher.HashPassword(newUser, user.Password);

            await _unitOfWork.Users.AddAsync(newUser);
            await _unitOfWork.CommitAsync(); // Commit via Unit of Work

            return newUser?.Adapt<AddUserDTO>();
        }

        public async Task<UserDTO> getUserById(int id)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(id);
            return user?.Adapt<UserDTO>();
        }

        public async Task<List<UserIformationDTO>> getAllClient()
        {
            var users = await _unitOfWork.Users.GetAllAsync(s => s.Status == UserStatus.Client);
            return users.Adapt<List<UserIformationDTO>>();
        }

        public async Task<List<UserIformationDTO>> getAllAdmin()
        {
            var users = await _unitOfWork.Users.GetAllAsync(s => s.Status == UserStatus.Admin);
            return users.Adapt<List<UserIformationDTO>>();
        }

        public async Task<UpdateUserAccountDTO> Update(int id, UpdateUserAccountDTO entity)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(id);
            if (user == null)
            {
                throw new Exception($"User with ID {id} not found");
            }

            // Map the DTO to the existing user entity
            entity.Adapt(user); // This updates the existing user with values from the DTO
            await _unitOfWork.Users.Update(user);
            await _unitOfWork.CommitAsync(); // Commit via Unit of Work

            return user.Adapt<UpdateUserAccountDTO>();
        }

        public async Task<UserDTO> Delete(string userName)
        {
            var user = await _unitOfWork.Users.FirstOrDefaultAsync(u => u.Username == userName);
            if (user == null)
            {
                throw new Exception($"User with username {userName} not found");
            }

            await _unitOfWork.Users.Delete(user);
            await _unitOfWork.Users.CommitAsync(); // Commit via Unit of Work

            return user.Adapt<UserDTO>();
        }

        public async Task activateUser(int id)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(id);
            if (user != null)
            {
                user.IsActive = true;
                await _unitOfWork.Users.Update(user);
                await _unitOfWork.CommitAsync(); // Commit via Unit of Work
            }
        }

        public async Task deactivateUser(int id)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(id);
            if (user != null)
            {
                user.IsActive = false;
                await _unitOfWork.Users.Update(user);
                await _unitOfWork.CommitAsync(); // Commit via Unit of Work
            }
        }
        public async Task<User> GetUserByNameAsync(string userName)
        {
            var user = await _unitOfWork.Users.GetUserByName(userName);
            return user;
        }
    }
}
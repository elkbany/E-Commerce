using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce.BL.Contracts.Repositories;
using E_Commerce.BL.Contracts.Services;
using E_Commerce.BL.Features.User.DTOs;
using E_Commerce.Domain.Enums;
using E_Commerce.Domain.Models;
using Mapster;

namespace E_Commerce.BL.Implementations
{
    public class UserServices:IUserServices
    {
        private IUserRepository _userRepository;
        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<UserDTO> AddUserAsync(UserDTO user)
        {
            var newUser = new User
            {
                Username = user.Username,
                PasswordHash = user.Password,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Status = UserStatus.Client
            };
            var AddUser = _userRepository.AddAsync(newUser);
            await _userRepository.CommitAsync();
            return newUser?.Adapt<UserDTO>();
        }
        public async Task<AddUserDTO> AddUserByAdminAsync(AddUserDTO user)
        {
            var newUser = new User
            {
                Username = user.Username,
                PasswordHash = user.Password,
                Email = user.Email,
                Status = (UserStatus)Enum.Parse(typeof(UserStatus), user.status),
                // Status = user.status,
            };
            var AddUser = _userRepository.AddAsync(newUser);
            await _userRepository.CommitAsync();
            return newUser?.Adapt<AddUserDTO>();
        }

        public async Task<UserDTO> getUserById(int ID)
        {

            var AddUser = _userRepository.GetByIdAsync(ID);
            return AddUser.Adapt<UserDTO>();
        }

        //public async Task<List<UserDTO>> getAllUser()
        //{

        //    var AddUser = _userRepository.GetAllAsync();
        //    return AddUser.Adapt<List<UserDTO>>();
        //}
        public async Task<List<UserIformationDTO>> getAllClient()
        {

            var AddUser = _userRepository.GetAllAsync(s => s.Status == UserStatus.Client);
            return AddUser.Adapt<List<UserIformationDTO>>();
        }
        public async Task<List<UserIformationDTO>> getAllAdmin()
        {

            var AddUser = _userRepository.GetAllAsync(s => s.Status == UserStatus.Admin);
            return AddUser.Adapt<List<UserIformationDTO>>();
        }
        public async Task<UpdateUserAccountDTO> Update(int Id, UpdateUserAccountDTO entity)
        {
            var TheUser = _userRepository.GetByIdAsync(Id);
            if (TheUser == null)
            {
                throw new Exception($"User with ID {Id} not found");

            }

            var UserUpdated = entity.Adapt<User>();
            var updatedAccount = _userRepository.Update(UserUpdated);
            await _userRepository.CommitAsync();
            return updatedAccount.Adapt<UpdateUserAccountDTO>();


        }
        public async Task<UserDTO> Delete(int Id)
        {
            var TheUser = await _userRepository.GetByIdAsync(Id);
            if (TheUser == null)
            {
                throw new Exception($"User with ID {Id} not found");
            }

            var user = _userRepository.Delete(TheUser);
            await _userRepository.CommitAsync();
            return user.Adapt<UserDTO>();
        }
        public async Task activateUser(int Id)
        {
            var user =await _userRepository.GetByIdAsync(Id);
            if (user != null) 
            {
                user.IsActive = true;
                await _userRepository.Update(user);
                await _userRepository.CommitAsync();
            }
           
        }

        public async Task deactivateUser(int Id)
        {
            var user = await _userRepository.GetByIdAsync(Id);
            if (user != null)
            {
                user.IsActive = false;
                await _userRepository.Update(user);
                await _userRepository.CommitAsync();
            }

        }
    }
}

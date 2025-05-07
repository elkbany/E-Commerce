using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce.BL.Contracts.Repositories;
using E_Commerce.BL.Contracts.Services;
using E_Commerce.BL.Features.User.UserDTO;
using E_Commerce.Domain.Models;
using Mapster;

namespace E_Commerce.BL.Implementations
{
    class UserServices:IUserServices
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
                LastName = user.LastName

            };
            var AddUser = _userRepository.AddAsync(newUser);
            await _userRepository.CommitAsync();
            return newUser?.Adapt<UserDTO>();
        }

        public async Task<UserDTO> getUserById(int ID)
        {

            var AddUser = _userRepository.GetByIdAsync(ID);
            return AddUser.Adapt<UserDTO>();
        }

        public async Task<List<UserDTO>> getAllUser()
        {

            var AddUser = _userRepository.GetAllAsync();
            return AddUser.Adapt<List<UserDTO>>();
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
        public async Task<UserDTO> Delete(int Id, User entity)
        {
            var TheUser = _userRepository.GetByIdAsync(Id);
            if (TheUser == null)
            {
                throw new Exception($"User with ID {Id} not found");
            }

            var user = _userRepository.Delete(entity);
            await _userRepository.CommitAsync();
            return user.Adapt<UserDTO>();
        }

    }
}

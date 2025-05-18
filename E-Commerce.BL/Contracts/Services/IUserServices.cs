using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce.BL.Contracts.Repositories;
using E_Commerce.BL.Features.User.DTOs;
using E_Commerce.Domain.Models;

namespace E_Commerce.BL.Contracts.Services
{
    public interface IUserServices
    {
        public Task<(UserDTO, bool IsActive)> AddUserAsync(UserDTO user);
        Task<UserDTO> getUserById(int ID);
        //Task<List<UserDTO>> getAllUser();
        Task<List<UserIformationDTO>> getAllClient();
        Task<List<UserIformationDTO>> getAllAdmin();
        Task<UpdateUserAccountDTO> Update(int Id, UpdateUserAccountDTO entity);
        Task<UserDTO> Delete(string userName);
        Task activateUser(int Id);
        Task deactivateUser(int Id);

    }
}

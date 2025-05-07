using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce.BL.Features.User.UserDTO;
using E_Commerce.Domain.Models;

namespace E_Commerce.BL.Contracts.Services
{
   public interface IUserServices
    {
        Task<UserDTO> AddUserAsync(UserDTO user);
        Task<UserDTO> getUserById(int ID);
        Task<List<UserDTO>> getAllUser();
        Task<UpdateUserAccountDTO> Update(int Id, UpdateUserAccountDTO entity);
        Task<UserDTO> Delete(int Id, User entity); 
    }
}

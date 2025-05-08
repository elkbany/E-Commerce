using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce.Domain.Models;

namespace E_Commerce.BL.Contracts.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        public Task<bool> IsUsernameTakenAsync(string username);
        public Task<bool> IsEmailAlreadyExistsAsync(string email);


    }
}

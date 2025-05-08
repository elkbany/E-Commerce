using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce.BL.Contracts.Repositories;
using E_Commerce.DA.Context;
using E_Commerce.DA.Implementations.Base;
using E_Commerce.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.DA.Implementations.Repositories
{
    public class UserRepository : GenericRepository<User>,IUserRepository
    {
        public UserRepository(DBContext context) : base(context)
        {
        }
        public async Task<bool> IsUsernameTakenAsync(string username)
        {
            return await _context.Users.AnyAsync(u => u.Username.ToLower() == username.ToLower());
        }
        public async Task<bool> IsEmailAlreadyExistsAsync(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email.ToLower() == email.ToLower());
        }
    }
}

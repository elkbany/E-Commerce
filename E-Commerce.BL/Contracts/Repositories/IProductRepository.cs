using E_Commerce.Domain.Models;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BL.Contracts.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Product GetByName(string name);
        Task<Product> GetByIdAsync(int id, IDbContextTransaction transaction = null); // دالة مع Transaction اختياري    }
    }
}
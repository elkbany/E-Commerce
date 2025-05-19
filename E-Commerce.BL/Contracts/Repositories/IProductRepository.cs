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
        public Task<IEnumerable<Product>> GetAllAsync(Expression<Func<Product, bool>>? filter = null, params Expression<Func<Product, object>>[] includes);
        public  Task<bool> IsProductNameExistsAsync(string name);

    }
}
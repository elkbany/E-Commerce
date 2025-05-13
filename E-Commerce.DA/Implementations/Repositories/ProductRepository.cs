using E_Commerce.BL.Contracts.Repositories;
using E_Commerce.DA.Context;
using E_Commerce.DA.Implementations.Base;
using E_Commerce.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DA.Implementations.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(DBContext context) : base(context)
        {
            
        }
        public Product GetByName(string name)
        {
            return _context.Products.Where(n => n.Name == name).FirstOrDefault();
        }
        public async Task<Product> GetByIdAsync(int id, IDbContextTransaction transaction = null)
        {
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
            // مفيش حاجة نعملها مع الـ Transaction هنا لأن الـ SaveChanges هيتم من الـ Service
        }
    }
}


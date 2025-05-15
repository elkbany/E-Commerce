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
        }
        public async Task<IEnumerable<Product>> GetAllAsync(Expression<Func<Product, bool>>? filter = null, params Expression<Func<Product, object>>[] includes)
        {
            IQueryable<Product> query = _context.Products;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return await query.ToListAsync();
        }
    }
}


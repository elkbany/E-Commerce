using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BL.Contracts.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        public Task<T> AddAsync(T entity);
        public Task<T> Update(T entity);
        public Task<T> Delete(T entity);
        public Task<T> GetByIdAsync(int id);
        public Task<IQueryable<T>> GetAllAsync(); 
        public Task CommitAsync();

        
    }
}

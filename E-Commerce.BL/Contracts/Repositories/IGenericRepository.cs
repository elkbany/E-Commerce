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
        public Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> criteria, params Expression<Func<T, object>>[] includes);
        public Task<List<T>> GetAllAsync(int skip, int take, params Expression<Func<T, object>>[] includes);
        public Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? criteria, int? skip, int? take, params Expression<Func<T, object>>[] includes);
        public Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? criteria = null, params Expression<Func<T, object>>[] includes);
        public Task<bool> AnyAsync(Expression<Func<T, bool>>? criteria = null);
        public Task<int> CountAsync(Expression<Func<T, bool>>? criteria = null);
        public Task CommitAsync();
    }
}

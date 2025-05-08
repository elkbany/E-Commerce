using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce.DA.Context;
using Microsoft.EntityFrameworkCore;
using E_Commerce.BL.Contracts.Repositories;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Metadata;



namespace E_Commerce.DA.Implementations.Base
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly DBContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(DBContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }
        public async Task<T> Update(T entity)
        {
            return _dbSet.Update(entity).Entity;
        }

        public async Task<T> Delete(T entity)
        {
            return _dbSet.Remove(entity).Entity;
        }

        public async Task<IQueryable<T>> GetAllAsync()
        {
            return await Task.FromResult(_dbSet.AsQueryable());
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task CommitAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                // Handle concurrency exception
                throw new Exception("Concurrency error occurred while saving changes.", ex);
            }
            catch (DbUpdateException ex)
            {
                // Handle update exception
                throw new Exception("An error occurred while updating the database.", ex);
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                throw new Exception("An unexpected error occurred.", ex);
            }
        }
        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> criteria, params Expression<Func<T, object>>[] includes)
        {
            var query = GetWhere(criteria, includes);
            return await query.FirstOrDefaultAsync();
        }
        public async Task<List<T>> GetAllAsync(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.ToListAsync();
        }
        public async Task<List<T>> GetAllAsync(int skip, int take, params Expression<Func<T, object>>[] includes)
        {
            var query = Includes(_dbSet, includes);

            var items = await query.Skip(skip).Take(take).ToListAsync();

            return query.ToList();
        }
        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? criteria, int? skip, int? take, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;

            if (criteria != null)
                query = query.Where(criteria);

            query = Includes(query, includes);

            if (skip.HasValue)
                query = query.Skip(skip.Value);

            if (take.HasValue)
                query = query.Take(take.Value);

            return await query.ToListAsync();
        }
        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? criteria = null, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;

            if (criteria != null)
                query = query.Where(criteria);

            query = Includes(query, includes);

            return await query.ToListAsync();
        }
       
        //public Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includes)
        //{
        //    var query = Includes(_dbSet, includes);
        //    return query.FirstOrDefaultAsync(e => e==id);
        //}
        public async Task<bool> AnyAsync(Expression<Func<T, bool>>? criteria = null)
        {
            return criteria == null ? await _dbSet.AnyAsync() : await _dbSet.AnyAsync(criteria);
        }
        public  async Task<int> CountAsync(Expression<Func<T, bool>>? criteria = null)
        {
            return criteria == null ? await _dbSet.CountAsync() : await _dbSet.CountAsync(criteria);
        }
        private IQueryable<T> Includes(IQueryable<T> query, params Expression<Func<T, object>>[] includes)
        {
            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);

            return query;
        }
        private IQueryable<T> GetWhere(Expression<Func<T, bool>> criteria, params Expression<Func<T, object>>[] includes)
        {
            var query = Includes(_dbSet, includes);

            return query.Where(criteria);
        }
    }
}

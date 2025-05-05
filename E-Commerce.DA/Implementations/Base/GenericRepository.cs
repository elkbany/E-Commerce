using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce.DA.Context;
using Microsoft.EntityFrameworkCore;



namespace E_Commerce.DA.Implementations.Base
{
    public class GenericRepository<T> where T : class
    {
        private readonly DBContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(DBContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public T Create(T entity) {return _dbSet.Add(entity).Entity;}
        public T Update(T entity) { return _dbSet.Update(entity).Entity; }
        public T Delete(T entity) { return _dbSet.Remove(entity).Entity; }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet.AsQueryable();
        }

        public void SaveChanges()
        {
            try
            {
                _context.SaveChanges();
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

    }
}

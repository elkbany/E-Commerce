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
        }


    }
}

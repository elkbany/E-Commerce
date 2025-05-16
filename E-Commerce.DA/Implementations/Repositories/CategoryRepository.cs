using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce.BL.Contracts.Repositories;
using E_Commerce.BL.Features.Category.DTOs;
using E_Commerce.DA.Context;
using E_Commerce.DA.Implementations.Base;
using E_Commerce.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.DA.Implementations.Repositories
{
   public class CategoryRepository : GenericRepository<Category> , ICategoryRepository
    {
        private readonly DbContext _context;
        public CategoryRepository(DBContext context): base(context)
        {
            _context = context;


        }
        public async Task<Category> Update(Category entity)
        {
            Console.WriteLine($"[CategoryRepository] Update called for Id={entity.Id}, Name={entity.Name}");
            _context.Update(entity);
            await _context.SaveChangesAsync();
            Console.WriteLine($"[CategoryRepository] Category updated: Id={entity.Id}, Name={entity.Name}");
            return entity;
        }


    }
}


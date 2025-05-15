using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce.BL.Features.Category.DTOs;
using E_Commerce.Domain.Models;

namespace E_Commerce.BL.Contracts.Services
{
    public interface ICategoryServices 
    {
        Task<CategoryDTO> AddCategoryAsync(CategoryDTO categoryDTO);
     
        Task<CategoryDTO> UpdateCategoryAsync(int id, CategoryDTO categoryDTO);
        Task<CategoryDTO> GetCategoryByIdAsync(int id);
        Task DeleteCategoryAsync(int id);
        Task<List<CategoryDTO>> GetAllCategoryAsync();
        Task<CategoryDTO> GetCategoryByNameAsync(string name);

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce.BL.Contracts.Repositories;
using E_Commerce.BL.Contracts.Services;
using E_Commerce.BL.Features.Category.DTOs;
using E_Commerce.BL.Features.Category.Validators;
using E_Commerce.BL.Features.Product.DTOs;
using E_Commerce.Domain.Models;
using Mapster;

namespace E_Commerce.BL.Implementations
{
    public class CategoryServices : AppService, ICategoryServices
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryServices(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository; 
        }

        public async Task<CategoryDTO> AddCategoryAsync(CategoryDTO categoryDTO)
        {
            #region Validations
            await DoValidationAsync<CategoryDTOValidator, CategoryDTO>(categoryDTO);

            var cat = new Category
            {
                Name = categoryDTO.Name,
              //  Description = categoryDTO.Description
            };
            #endregion
            var Cat = await categoryRepository.AddAsync(cat);
            var catMap = categoryDTO?.Adapt<CategoryDTO>();
            return catMap;
        }
      

        public async Task DeleteCategoryAsync(int id)
        {
            var cat = await categoryRepository.GetByIdAsync(id);
            if(cat != null)
            {
                await categoryRepository.Delete(cat);
            }

        }

        public async Task<List<CategoryDTO>> GetAllCategoryAsync()
        {
            var cats = await categoryRepository.GetAllAsync();
            var catsMap = cats.Adapt<List<CategoryDTO>>();
            return catsMap;
         
        }

        public async Task<CategoryDTO> GetCategoryByIdAsync(int id)
        {
            var cat = await categoryRepository.GetByIdAsync(id);
            var catMap = cat?.Adapt<CategoryDTO>();
            return catMap;
        }

        public async Task<CategoryDTO> UpdateCategoryAsync(int id, CategoryDTO category)
        {
            var cateogry = await categoryRepository.GetByIdAsync(id); 
            var cat = await categoryRepository.Update(cateogry);
            var catMap = category?.Adapt<CategoryDTO>();
            return catMap;
        }
        public async Task<CategoryDTO> GetCategoryByNameAsync(string name)
        {
            var cat = (await categoryRepository.GetAllAsync()).FirstOrDefault(c => c.Name == name);
            return cat?.Adapt<CategoryDTO>();
        }
        }
        public async Task<Category> getCategoryIDByName(string name)
        {
            return await categoryRepository.FirstOrDefaultAsync(c => c.Name == name);
  
        }
    }
}

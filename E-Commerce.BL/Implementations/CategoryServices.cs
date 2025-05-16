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
        private readonly IProductRepository productRepository;

        public CategoryServices(ICategoryRepository categoryRepository, IProductRepository productRepository)
        {
            this.categoryRepository = categoryRepository;
            this.productRepository = productRepository;
        }

        public async Task<CategoryDTO> AddCategoryAsync(CategoryDTO categoryDTO)
        {
            try
            {
                Console.WriteLine($"[CategoryServices] AddCategoryAsync called for Name={categoryDTO.Name}");
                await DoValidationAsync<CategoryDTOValidator, CategoryDTO>(categoryDTO);

                var cat = new Category
                {
                    Name = categoryDTO.Name,
                    Description = categoryDTO.Description 
                };
                var addedCat = await categoryRepository.AddAsync(cat);
                categoryRepository.CommitAsync();
                Console.WriteLine($"[CategoryServices] Category added: Id={addedCat.Id}, Name={addedCat.Name}");
                return addedCat.Adapt<CategoryDTO>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[CategoryServices] Error in AddCategoryAsync: {ex.Message}\nStackTrace: {ex.StackTrace}");
                throw;
            }
        }


        public async Task DeleteCategoryAsync(int id)
        {
            var category = await categoryRepository.GetByIdAsync(id);
            if (category == null) throw new Exception("Category not found.");

            
            var products = await productRepository.GetAllAsync(p => p.CategoryID == id);
            if (products.Any())
            {
                throw new Exception("Cannot delete category. It has associated products.");
            }

            await categoryRepository.Delete(category);
            categoryRepository.CommitAsync();

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
            try
            {
                Console.WriteLine($"[CategoryServices] UpdateCategoryAsync called for Id={id}, Name={category.Name}");
                var existing = await categoryRepository.GetByIdAsync(id);
                if (existing == null)
                {
                    Console.WriteLine("[CategoryServices] Category not found.");
                    throw new Exception("Category not found.");
                }

                existing.Name = category.Name;
                existing.Description = category.Description;
                await categoryRepository.Update(existing);
                Console.WriteLine($"[CategoryServices] Category updated: Id={existing.Id}, Name={existing.Name}");

                
                var updatedCat = await categoryRepository.GetByIdAsync(id);
                if (updatedCat == null || updatedCat.Name != category.Name || updatedCat.Description != category.Description)
                {
                    Console.WriteLine("[CategoryServices] Update did not reflect in database immediately.");
                    throw new Exception("Update did not reflect in database immediately.");
                }
                Console.WriteLine($"[CategoryServices] Confirmed update in database: Id={updatedCat.Id}, Name={updatedCat.Name}");

                return updatedCat.Adapt<CategoryDTO>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[CategoryServices] Error in UpdateCategoryAsync: {ex.Message}\nStackTrace: {ex.StackTrace}");
                throw;
            }
        }

        public async Task<CategoryDTO> GetCategoryByNameAsync(string name)
        {
            var cat = (await categoryRepository.GetAllAsync()).FirstOrDefault(c => c.Name == name);
            return cat?.Adapt<CategoryDTO>();
        }
        
        public async Task<Category> getCategoryIDByName(string name)
        {
            return await categoryRepository.FirstOrDefaultAsync(c => c.Name == name);
  
        }
    }
}

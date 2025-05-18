using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_Commerce.BL.Contracts.Repositories;
using E_Commerce.BL.Contracts.Services;
using E_Commerce.BL.Features.Category.DTOs;
using E_Commerce.BL.Features.Category.Validators;
using E_Commerce.Domain.Models;
using Mapster;

namespace E_Commerce.BL.Implementations
{
    public class CategoryServices : AppService, ICategoryServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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

                var addedCat = await _unitOfWork.Categories.AddAsync(cat);
                await _unitOfWork.CommitAsync();

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
            var category = await _unitOfWork.Categories.GetByIdAsync(id);
            if (category == null)
                throw new Exception("Category not found.");

            var products = await _unitOfWork.Products.GetAllAsync(p => p.CategoryID == id);
            if (products.Any())
                throw new Exception("Cannot delete category. It has associated products.");

            await _unitOfWork.Categories.Delete(category);
            await _unitOfWork.CommitAsync();
        }

        public async Task<List<CategoryDTO>> GetAllCategoryAsync()
        {
            var cats = await _unitOfWork.Categories.GetAllAsync();
            return cats.Adapt<List<CategoryDTO>>();
        }

        public async Task<CategoryDTO> GetCategoryByIdAsync(int id)
        {
            var cat = await _unitOfWork.Categories.GetByIdAsync(id);
            return cat?.Adapt<CategoryDTO>();
        }

        public async Task<CategoryDTO> UpdateCategoryAsync(int id, CategoryDTO category)
        {
            try
            {
                Console.WriteLine($"[CategoryServices] UpdateCategoryAsync called for Id={id}, Name={category.Name}");
                var existing = await _unitOfWork.Categories.GetByIdAsync(id);

                if (existing == null)
                {
                    Console.WriteLine("[CategoryServices] Category not found.");
                    throw new Exception("Category not found.");
                }

                existing.Name = category.Name;
                existing.Description = category.Description;

                await _unitOfWork.Categories.Update(existing);
                await _unitOfWork.CommitAsync();

                var updatedCat = await _unitOfWork.Categories.GetByIdAsync(id);
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
            var cat = (await _unitOfWork.Categories.GetAllAsync())
                        .FirstOrDefault(c => c.Name == name);
            return cat?.Adapt<CategoryDTO>();
        }

        public async Task<Category> getCategoryIDByName(string name)
        {
            return await _unitOfWork.Categories.FirstOrDefaultAsync(c => c.Name == name);
        }
    }
}

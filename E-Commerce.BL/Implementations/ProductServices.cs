using E_Commerce.BL.Contracts.Repositories;
using E_Commerce.BL.Contracts.Services;
using E_Commerce.BL.Features.Product.DTOs;
using E_Commerce.BL.Features.Product.Validators;
using E_Commerce.Domain.Models;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.BL.Implementations
{
    public class ProductServices : AppService, IProductServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICategoryServices _categoryServices;

        public ProductServices(IUnitOfWork unitOfWork, ICategoryServices categoryServices)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _categoryServices = categoryServices ?? throw new ArgumentNullException(nameof(categoryServices));
        }

        public async Task<AddProductDTO> AddProductAsync(AddProductDTO product)
        {
            var category = await _categoryServices.getCategoryIDByName(product.Category);

            #region Validations
            await DoValidationAsync<ProductDTOValidator, AddProductDTO>(product);
            var pro = new Product
            {
                Name = product.Name,
                Price = product.Price,
                UnitsInStock = product.UnitsInStock,
                CategoryID = category.Id,
                Description = string.Empty,
            };
            #endregion

            await _unitOfWork.Products.AddAsync(pro);
            await _unitOfWork.CommitAsync(); // Commit via Unit of Work

            var proMap = pro?.Adapt<AddProductDTO>();
            return proMap;
        }

        public async Task<ProductDTO> GetProductByIdAsync(int id)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);
            var proMap = product?.Adapt<ProductDTO>();
            return proMap;
        }

        public async Task<IEnumerable<ProductDTO>> GetAllProductsAsync()
        {
            var products = await _unitOfWork.Products.GetAllAsync(null, p => p.Category);
            return products.Adapt<List<ProductDTO>>();
        }

        public async Task<ProductDTO> UpdateProductAsync(int id, ProductDTO productDTO)
        {
            var existing = await _unitOfWork.Products.GetByIdAsync(id);
            if (existing == null)
                throw new Exception($"Product with ID {id} not found.");

            existing.Name = productDTO.Name;
            existing.Description = productDTO.Description;
            existing.Price = productDTO.Price;
            existing.UnitsInStock = productDTO.UnitsInStock != existing.UnitsInStock ? productDTO.UnitsInStock : existing.UnitsInStock;

            await _unitOfWork.Products.Update(existing);
            await _unitOfWork.CommitAsync(); // Commit via Unit of Work

            return existing.Adapt<ProductDTO>();
        }

        public async Task<AddProductDTO> UpdateProductByAdminAsync(int id, AddProductDTO addProductDTO)
        {
            var category = await _categoryServices.getCategoryIDByName(addProductDTO.Category);
            var existing = await _unitOfWork.Products.GetByIdAsync(id);
            if (existing == null)
                throw new Exception($"Product with ID {id} not found.");

            existing.Name = addProductDTO.Name;
            existing.Price = addProductDTO.Price;
            existing.UnitsInStock = addProductDTO.UnitsInStock;
            existing.CategoryID = category.Id;

            await _unitOfWork.Products.Update(existing);
            await _unitOfWork.Products.CommitAsync(); // Commit via Unit of Work

            return existing.Adapt<AddProductDTO>();
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);
            if (product != null)
            {
                await _unitOfWork.Products.Delete(product);
                await _unitOfWork.Products.CommitAsync(); // Commit via Unit of Work
            }
        }

        public async Task<List<AvaliableProductDTO>> GetAvalibaleProducts()
        {
            var products = await _unitOfWork.Products.GetAllAsync(p => p.UnitsInStock > 0);
            return products.Adapt<List<AvaliableProductDTO>>();
        }

        public async Task<ProductDetailesDTO> ProductDetailes(string name)
        {
            var product = await _unitOfWork.Products.FirstOrDefaultAsync(p => p.Name == name);
            return product?.Adapt<ProductDetailesDTO>();
        }

        public async Task<List<ProductDTO>> GetAllProductsByCatigory(Category category)
        {
            var products = await _unitOfWork.Products.GetAllAsync(p => p.Category == category);
            var proMap = products.Adapt<List<ProductDTO>>();
            return proMap;
        }

        public async Task<List<ProductDTO>> GetAllProductsByCategory(Category category)
        {
            var products = await _unitOfWork.Products.GetAllAsync(p => p.Category == category);
            var proMap = products.Adapt<List<ProductDTO>>();
            return proMap;
        }

        public async Task<List<ProductDTO>> SearchProductsByName(string productName)
        {
            if (string.IsNullOrWhiteSpace(productName))
            {
                return new List<ProductDTO>();
            }

            var products = await _unitOfWork.Products.GetAllAsync(p => p.Name != null && p.Name.ToLower().Contains(productName.ToLower()));
            return products.Adapt<List<ProductDTO>>();
        }

        public async Task<Product> GetProductByName(string name)
        {
            return await _unitOfWork.Products.FirstOrDefaultAsync(p => p.Name == name);
        }
    }
}
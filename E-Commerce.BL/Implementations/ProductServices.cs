using E_Commerce.BL.Contracts.Repositories;
using E_Commerce.BL.Contracts.Services;
using E_Commerce.BL.Features.Product.DTOs;
using E_Commerce.BL.Features.Product.Validators;
using E_Commerce.Domain.Models;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BL.Implementations
{
    public class ProductServices : AppService,IProductServices
    {
        private readonly IProductRepository _productRepository;

        public ProductServices(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<ProductDTO> AddProductAsync(ProductDTO product)
        {
            #region Validations
            await DoValidationAsync<ProductDTOValidator, ProductDTO>(product);
            //var category = 
            var pro = new Product
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                UnitsInStock = product.UnitsInStock,

            }; 
            #endregion
                
            var Pro =await productRepository.AddAsync(pro);
            var proMap = product?.Adapt<ProductDTO>();
            return proMap;
        }

        public async Task<ProductDTO> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            var proMap = product?.Adapt<ProductDTO>();
            return proMap;
        }

        public async Task<IEnumerable<ProductDTO>> GetAllProductsAsync()
        {
            var products = _productRepository.GetAllAsync();
            var proMap = products.Adapt<List<ProductDTO>>();
            return proMap;
        }

        public async Task<ProductDTO> UpdateProductAsync(int id,ProductDTO productDTO)
        {
            var product = await productRepository.GetByIdAsync(id);
            var pro = await productRepository.Update(product);
            var proMap = product?.Adapt<ProductDTO>();
            return proMap;
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product != null)
            {
                await _productRepository.Delete(product);
            }
        }
    }
}


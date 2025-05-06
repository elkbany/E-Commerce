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
        private readonly IProductRepository productRepository;

        public ProductServices(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public async Task<ProductDTO> AddProductAsync(ProductDTO product)
        {
            await DoValidationAsync<ProductDTOValidator,ProductDTO>(product);
            //var category = 
            var pro = new Product
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                UnitsInStock = product.UnitsInStock,

            };

            var Pro = await productRepository.AddAsync(pro);
            var proMap = product?.Adapt<ProductDTO>();
            return proMap;
        }

        public async Task<ProductDTO> GetProductByIdAsync(int id)
        {
            var product = await productRepository.GetByIdAsync(id);
            var proMap = product?.Adapt<ProductDTO>();
            return proMap;
        }

        public async Task<IEnumerable<ProductDTO>> GetAllProductsAsync()
        {
            var products = productRepository.GetAllAsync();
            var proMap = products.Adapt<List<ProductDTO>>();
            return proMap;
        }

        public async Task<ProductDTO> UpdateProductAsync(Product product)
        {
            var pro = await productRepository.Update(product);
            var proMap = product?.Adapt<ProductDTO>();
            return proMap;
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await productRepository.GetByIdAsync(id);
            if (product != null)
            {
                await productRepository.Delete(product);
            }
        }
    }
}


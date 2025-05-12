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
    public class ProductServices : AppService, IProductServices
    {
        private readonly IProductRepository productRepository;

        public ProductServices(IProductRepository productRepository)
        {
            this.productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
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
          // await productRepository.GetAllAsync(p=>p.UnitsInStock>0);
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

        public async Task<ProductDTO> UpdateProductAsync(int id,ProductDTO productDTO)
        {
            var product = await productRepository.GetByIdAsync(id);
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
        //public async Task<List<Product>> GetAllp()
        //{
        //    var products = await productRepository.GetAllAsync(p=>p.UnitsInStock>0);
        //    var proMap = products.Adapt<List<Product>>();
        //    return proMap;
        //}
        public async Task<List<AvaliableProductDTO>> GetAvalibaleProducts()
        {
            var products = await productRepository.GetAllAsync(p => p.UnitsInStock > 0);
            return products.Adapt<List<AvaliableProductDTO>>();
        }

        public async Task<ProductDetailesDTO> ProductDetailes(string name)
        {
            var product = productRepository.GetByName(name);
            return product?.Adapt<ProductDetailesDTO>();/////if no product no output
        }

        public async Task<List<ProductDTO>> GetAllProductsByCatigory(Category category)
        {
            var products = productRepository.GetAllAsync(p=>p.Category== category);
            var proMap = products.Adapt<List<ProductDTO>>();
            return proMap;

        }
        public async Task<List<ProductDTO>> GetAllProductsByCategory(Category category)
        {
           
              
                var products = await productRepository.GetAllAsync(p => p.Category == category);

              
                var proMap = products.Adapt<List<ProductDTO>>();

                return proMap;
            
           
        }
        public async Task<List<ProductDTO>> SearchProductsByName(string ProductName)
        {
         
              
                if (string.IsNullOrWhiteSpace(ProductName))
                {
                    return new List<ProductDTO>();
                }

               
                var products = await productRepository.GetAllAsync(p => p.Name != null && p.Name.ToLower().Contains(ProductName.ToLower()));
                return products.Adapt<List<ProductDTO>>();
            
           
                
            
        }

    }
}


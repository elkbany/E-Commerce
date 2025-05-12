using E_Commerce.BL.Features.Product.DTOs;
using E_Commerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce.BL.Features.Product.DTOs;
using E_Commerce.Domain.Models;
using E_Commerce.BL.Contracts.Repositories;

namespace E_Commerce.BL.Contracts.Services
{
    public interface IProductServices
    {
        Task<ProductDTO> AddProductAsync(ProductDTO product);
        Task<ProductDTO> GetProductByIdAsync(int id);
        Task<IEnumerable<ProductDTO>> GetAllProductsAsync();
        Task<IEnumerable<ProductDTO>> GetAllProductsByCatigory();
        Task<IEnumerable<ProductDTO>> GetAllProductsByCatigoryName(string categoryName);
        Task<List<ProductDTO>> SearchProductsByName(string ProductName);
        Task<ProductDTO> UpdateProductAsync(int id, ProductDTO productDTO);
        Task DeleteProductAsync(int id);
        Task<List<AvaliableProductDTO>> GetAvalibaleProducts();
        Task<ProductDetailesDTO> ProductDetailes(string name);
       
    }
}

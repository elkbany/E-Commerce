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
        Task<AddProductDTO> AddProductAsync(AddProductDTO product);
        Task<ProductDTO> GetProductByIdAsync(int id);
        Task<IEnumerable<ProductDTO>> GetAllProductsAsync();
       
        Task<List<ProductDTO>> SearchProductsByName(string ProductName);

        Task<List<ProductDTO>> GetAllProductsByCatigory(Category category);

        Task<ProductDTO> UpdateProductAsync(int id, ProductDTO productDTO);
        Task DeleteProductAsync(int id);
        Task<List<AvaliableProductDTO>> GetAvalibaleProducts();
        Task<ProductDetailesDTO> ProductDetailes(string name);
        Task<Product> GetProductByName(string name);
        Task<AddProductDTO> UpdateProductByAdminAsync(int id, AddProductDTO addProductDTO);


    }
}

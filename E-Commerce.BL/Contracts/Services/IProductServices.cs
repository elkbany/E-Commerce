using E_Commerce.BL.Features.Product.DTOs;
using E_Commerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BL.Contracts.Services
{
    public interface IProductServices
    {
        Task<ProductDTO> AddProductAsync(ProductDTO product);
        Task<ProductDTO> GetProductByIdAsync(int id);
        Task<IEnumerable<ProductDTO>> GetAllProductsAsync();
        Task<ProductDTO> UpdateProductAsync(Product product);
        Task DeleteProductAsync(int id);
    }
}

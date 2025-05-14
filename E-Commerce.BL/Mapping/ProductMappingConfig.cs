using E_Commerce.Domain.Models;
using E_Commerce.BL.Features.Product.DTOs;
using Mapster;

namespace E_Commerce.BL.Configurations
{
    public static class ProductMappingConfig
    {
        public static void Configure()
        {
            TypeAdapterConfig<Product, ProductDTO>.NewConfig()
                .Map(dest => dest.Category, src => src.Category != null ? src.Category.Name : null);
        }
    }
}
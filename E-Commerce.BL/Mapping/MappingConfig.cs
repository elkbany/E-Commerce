using E_Commerce.BL.Features.Product.DTOs;
using E_Commerce.Domain.Models;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BL.Mapping
{
    public class MappingConfig
    {
        public void Configure()
        {

            TypeAdapterConfig<Product, ProductDTO>.NewConfig()
                .Map(dest => dest.Category, src => src.Category.Name);

        }
    }
}

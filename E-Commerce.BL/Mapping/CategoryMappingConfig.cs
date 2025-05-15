using E_Commerce.BL.Features.Category.DTOs;
using E_Commerce.Domain.Models;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BL.Mapping
{
    public static class CategoryMappingConfig
    {
        public static void Configure()
        {
            TypeAdapterConfig<Category, CategoryDTO>.NewConfig()
                .Map(dest => dest.Id, src => src.Id) 
                .Map(dest => dest.Name, src => src.Name);
        }
    }
}

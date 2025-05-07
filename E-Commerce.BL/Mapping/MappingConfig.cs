using E_Commerce.BL.Features.Product.DTOs;
using E_Commerce.BL.Features.User.UserDTO;
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

            #region User Mapping
            TypeAdapterConfig<User, UserDTO>.NewConfig()
              .Map(dest => dest.Username, src => src.Username)
              .Map(dest => dest.FirstName, src => src.FirstName)
              .Map(dest => dest.LastName, src => src.LastName)
              .Map(dest => dest.Password, src => src.PasswordHash)
              .Map(dest => dest.Email, src => src.Email);

            TypeAdapterConfig<UpdateUserAccountDTO, User>.NewConfig()
               .Map(dest => dest.FirstName, src => src.FirstName)
               .Map(dest => dest.LastName, src => src.LastName)
               .Map(dest => dest.PasswordHash, src => src.Password)
               .Map(dest => dest.Email, src => src.Email);
            #endregion


        }
    }
}

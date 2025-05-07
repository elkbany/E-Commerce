using E_Commerce.BL.Features.Category.DTOs;
using E_Commerce.BL.Features.Product.DTOs;
using E_Commerce.BL.Features.User.DTOs;
using E_Commerce.Domain.Models;
using E_Commerce.BL.Features.Product;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce.Domain.Models;
using E_Commerce.BL.Features.Order.DTOs;

namespace E_Commerce.BL.Mapping
{
    public class MappingConfig
    {
        public void Configure()
        {

            TypeAdapterConfig<Product, Features.Product.DTOs.ProductDTO>.NewConfig()
                .Map(dest => dest.Category, src => src.Category.Name);

            #region User Mapping
            TypeAdapterConfig<User, Features.User.DTOs.UserDTO>.NewConfig()
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


            TypeAdapterConfig<Category, CategoryDTO>.NewConfig();
            TypeAdapterConfig<Order, OrderDTO>
            .NewConfig()
            .Map(dest => dest.Status, src => src.Status.ToString());    
            //.Map(dest => dest.UserName, src => src.User.Username);
            //.Map(dest => dest.OrderDetails, src => src.OrderDetails);

            //TypeAdapterConfig<OrderDetail, OrderDetailDTO>
            //    .NewConfig()
            //    .Map(dest => dest.ProductName, src => src.Product?.Name);
        }
    }
}

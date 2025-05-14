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

using E_Commerce.BL.Features.Order.DTOs;
using E_Commerce.BL.Features.CartItem;
using System.Xml.Serialization;
using E_Commerce.BL.Features.CartItem.DTO;

namespace E_Commerce.BL.Mapping
{
    public class MappingConfig
    {
        public void Configure()
        {

            TypeAdapterConfig<Product, ProductDTO>.NewConfig()
            .Map(dest => dest.Category, src => src.Category != null ? src.Category.Name : null);

            #region User Mapping
            TypeAdapterConfig<User,UserDTO>.NewConfig()
              .Map(dest => dest.Username, src => src.Username)
              .Map(dest => dest.FirstName, src => src.FirstName)
              .Map(dest => dest.LastName, src => src.LastName)
              .Map(dest => dest.Password, src => src.PasswordHash)
              .Map(dest => dest.Email, src => src.Email);

            TypeAdapterConfig<UpdateUserAccountDTO, User>.NewConfig()
               .Map(dest => dest.FirstName, src => src.FirstName)
               .Map(dest => dest.LastName, src => src.LastName)
               //.Map(dest => dest.PasswordHash, src => src.Password)
               .Map(dest => dest.Email, src => src.Email);

            TypeAdapterConfig<User, UserIformationDTO>.NewConfig()
               .Map(dest => dest.FirstName, src => src.FirstName)
               .Map(dest => dest.LastName, src => src.LastName)
               .Map(dest => dest.Email, src => src.Email)
               .Map(dest => dest.Username, src => src.Username);
            #endregion

            #region Product Mapping

            TypeAdapterConfig<Product, ProductDetailesDTO>.NewConfig()
              .Map(dest => dest.Name, src => src.Name)
              .Map(dest => dest.Price, src => src.Price)
              .Map(dest => dest.Description, src => src.Description)
              .Map(dest => dest.UnitsInStock, src => src.UnitsInStock)
              .Map(dest => dest.Category, src => src.Category.Name);
            #endregion


            TypeAdapterConfig<Category, CategoryDTO>.NewConfig();
            TypeAdapterConfig<Order, OrderDTO>
            .NewConfig()
            .Map(dest => dest.Status, src => src.Status.ToString())  
            .Map(dest => dest.UserName, src => src.User.Username)
            .Map(dest => dest.OrderDetails, src => src.OrderDetails);

            TypeAdapterConfig<CartItem, CartItemDTO>.NewConfig()//////check
                .Map(dest => dest.ProductID, src => src.ProductID)
                .Map(dest => dest.ProductName, src => src.Product.Name)
                .Map(dest => dest.ProductPrice, src => src.Product.Price);

            // CartItem to CartItemDTO
            TypeAdapterConfig<CartItem, CartItemDTO>.NewConfig()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.ProductID, src => src.ProductID)
                .Map(dest => dest.ProductName, src => src.Product.Name)
                .Map(dest => dest.ProductPrice, src => src.Product.Price)
                .Map(dest => dest.Quantity, src => src.Quantity);

            // AddCartItemDTO to CartItem
            TypeAdapterConfig<AddCartItemDTO, CartItem>.NewConfig()
                .Map(dest => dest.UserID, src => src.UserId)
                .Map(dest => dest.ProductID, src => src.ProductId)
                .Map(dest => dest.Quantity, src => src.Quantity)
                .Map(dest => dest.DateAdded, src => DateTime.UtcNow);


            TypeAdapterConfig<Category, CategoryDTO>.NewConfig()
               
                .Map(dest => dest.Name, src => src.Name);

            //TypeAdapterConfig<OrderDetail, OrderDetailDTO>
            //    .NewConfig()
            //    .Map(dest => dest.ProductName, src => src.Product?.Name);
        }
    }
}

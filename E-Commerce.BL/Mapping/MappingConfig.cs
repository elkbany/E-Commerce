using E_Commerce.BL.Features.Product.DTOs;
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

            TypeAdapterConfig<Product, ProductDTO>.NewConfig()
                .Map(dest => dest.Category, src => src.Category.Name);

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

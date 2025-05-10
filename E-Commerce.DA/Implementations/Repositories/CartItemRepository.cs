using E_Commerce.BL.Contracts.Repositories;
using E_Commerce.DA.Context;
using E_Commerce.DA.Implementations.Base;
using E_Commerce.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DA.Implementations.Repositories
{
    public class CartItemRepository : GenericRepository<CartItem>, ICartItemRepository
    {
       
       
        public CartItemRepository(DBContext context) : base(context)
        {
        }
     


    }
}

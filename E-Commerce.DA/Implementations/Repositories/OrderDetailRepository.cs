  using E_Commerce.BL.Contracts.Repositories;
using E_Commerce.DA.Context;
using E_Commerce.DA.Implementations.Base;
using E_Commerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DA.Implementations.Repositories
{
    public class OrderDetailRepository : GenericRepository<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(DBContext context) : base(context)
        {

        }

        
    }
}

using E_Commerce.BL.Contracts.Repositories;
using E_Commerce.DA.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DA.Implementations.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DBContext _context;

        public IProductRepository Products { get; private set; }
        public ICategoryRepository Categories { get; private set; }
        public ICartItemRepository CartItems { get; private set; }
        public IOrderRepository Orders { get; private set; }
        public IOrderDetailRepository OrderDetails { get; private set; }
        public IUserRepository Users { get; private set; }

        public UnitOfWork(
            DBContext context,
            IProductRepository productRepository,
            ICategoryRepository categoryRepository,
            ICartItemRepository cartItemRepository,
            IOrderRepository orderRepository,
            IOrderDetailRepository orderDetailRepository,
            IUserRepository userRepository)
        {
            _context = context;

            Products = productRepository;
            Categories = categoryRepository;
            CartItems = cartItemRepository;
            Orders = orderRepository;
            OrderDetails = orderDetailRepository;
            Users = userRepository;
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

}

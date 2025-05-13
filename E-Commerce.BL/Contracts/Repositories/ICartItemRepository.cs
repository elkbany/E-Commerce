using E_Commerce.Domain.Models;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BL.Contracts.Repositories
{
    public interface ICartItemRepository: IGenericRepository<CartItem>

    {
        // أضف دوال الـ Transaction
        Task<IDbContextTransaction> BeginTransactionAsync();
        Task CommitTransactionAsync(IDbContextTransaction transaction);
        Task RollbackTransactionAsync(IDbContextTransaction transaction);

        Task<CartItem> AddAsync(CartItem entity, IDbContextTransaction transaction);
        Task CommitAsync(IDbContextTransaction transaction); // تعديل CommitAsync ليستخدم Transaction
    }
}


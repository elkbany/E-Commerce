using E_Commerce.BL.Contracts.Repositories;
using E_Commerce.DA.Implementations.Base;
using E_Commerce.Domain.Models;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using E_Commerce.DA.Context;

public class CartItemRepository : GenericRepository<CartItem>, ICartItemRepository
{
    public CartItemRepository(DBContext context) : base(context)
    {
    }

    public async Task<CartItem> AddAsync(CartItem entity, IDbContextTransaction transaction = null)
    {
        await _dbSet.AddAsync(entity); // دلوقتي هيشتغل لأن _dbSet protected
        if (transaction != null)
        {
            return entity;
        }
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task CommitAsync(IDbContextTransaction transaction = null)
    {
        if (transaction != null)
        {
            // الـ Commit هيتم من الـ Service
        }
        else
        {
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IDbContextTransaction> BeginTransactionAsync()
    {
        return await _context.Database.BeginTransactionAsync();
    }

    public async Task CommitTransactionAsync(IDbContextTransaction transaction)
    {
        await transaction.CommitAsync();
    }

    public async Task RollbackTransactionAsync(IDbContextTransaction transaction)
    {
        await transaction.RollbackAsync();
    }
}
using E_Commerce.BL.Contracts.Repositories;
using E_Commerce.DA.Implementations.Base;
using E_Commerce.Domain.Models;
using E_Commerce.DA.Context;
using Microsoft.EntityFrameworkCore;

public class CartItemRepository : GenericRepository<CartItem>, ICartItemRepository
{
    public CartItemRepository(DBContext context) : base(context)
    {
    }
}
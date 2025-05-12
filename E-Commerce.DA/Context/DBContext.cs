using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using E_Commerce.Domain.Enums;
using E_Commerce.Domain.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace E_Commerce.DA.Context
{
    public class DBContext : DbContext
    {
       

        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
           

            //options.UseSqlServer("Data Source=.;Initial Catalog=E-Commerce;Integrated Security=True;Trust Server Certificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region User
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasMany(u => u.Orders)
                .WithOne(o => o.User)
                .HasForeignKey(o => o.UserID)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<User>().HasMany(u => u.CartItems)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserID)
                .OnDelete(DeleteBehavior.Restrict);
            #endregion
            #region Order
            modelBuilder.Entity<Order>().HasMany(o => o.OrderDetails)
                .WithOne(od => od.Order)
                .HasForeignKey(od => od.OrderID)
                .OnDelete(DeleteBehavior.Restrict);
            #endregion
            #region OrderDetail
            modelBuilder.Entity<OrderDetail>().HasOne(od => od.Product)
                .WithMany(p => p.OrderDetails)
                .HasForeignKey(od => od.ProductID)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion
            #region Product
            modelBuilder.Entity<Product>().HasMany(p => p.OrderDetails)
                .WithOne(od => od.Product)
                .HasForeignKey(od => od.ProductID)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Product>().HasMany(p => p.CartItems)
                .WithOne(c => c.Product)
                .HasForeignKey(c => c.ProductID)
                .OnDelete(DeleteBehavior.Restrict);
            #endregion
            #region CartItem
            modelBuilder.Entity<CartItem>().HasOne(c => c.User)
                .WithMany(u => u.CartItems)
                .HasForeignKey(c => c.UserID)
                .OnDelete(DeleteBehavior.Restrict);
            #endregion
            #region Category
            modelBuilder.Entity<Category>().HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryID)
                .OnDelete(DeleteBehavior.Restrict);
            #endregion

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.TotalAmount)
                      .HasColumnType("decimal(18,2)"); // Precision 18, Scale 2
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Price)
                      .HasColumnType("decimal(18,2)"); // Precision 18, Scale 2
            });

          

            //var seedDate = new DateTime(2025, 5, 11, 0, 0, 0, DateTimeKind.Utc);
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Username = "AdminIbnAdmin",
                    Email = "admin@admin.com",
                    FirstName = "Admin",
                    LastName = "Admin",
                    Status = UserStatus.Admin,
                    IsActive = true,
                    DateCreated = DateTime.Parse("2025-05-11T00:00:00Z"),
                    DateUpdated = DateTime.Parse("2025-05-11T00:00:00Z"),
                    //admin@123
                    PasswordHash = "AQAAAAIAAYagAAAAECtJWIRqgoBEDzcFOu4Kz0LCY/MSge+0SZns5va/p5u6Gg4O87dz1beHha+iyFbsHA=="
                }
            );

            // Seed user 2
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 2,
                    Username = "UserIbnUser",
                    Email = "user@user.com",
                    FirstName = "User",
                    LastName = "User",
                    Status = UserStatus.Client,
                    IsActive = true,
                    DateCreated = DateTime.Parse("2025-05-11T00:00:00Z"),
                    DateUpdated = DateTime.Parse("2025-05-11T00:00:00Z"),
                    //user@123
                    PasswordHash = "AQAAAAIAAYagAAAAEBHDiyLRTxpFa9qgoSrzKlEMb2TQjBd1itcvuGrwgvtx80k7zeKga6KPH7+QO+522w=="
                }
                );
            modelBuilder.Entity<Order>().HasData(
           new Order
           {
               OrderID = 1,
               UserID = 1,
               OrderDate = DateTime.Parse("2025-05-11T00:00:00Z"),
               TotalAmount = 150.00m,
               Status = OrderStatus.Pending,
               DateProcessed = null
           }
       );

            // Seed order 2 (for User 2)
            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    OrderID = 2,
                    UserID = 2,
                    OrderDate = DateTime.Parse("2025-05-11T00:00:00Z").AddDays(1), // May 12, 2025
                    TotalAmount = 275.50m,
                    Status = OrderStatus.Approved,
                    DateProcessed = DateTime.Parse("2025-05-11T00:00:00Z").AddDays(1).AddHours(2) // May 12, 2025, 02:00:00 UTC
                }
            );
            modelBuilder.Entity<Category>().HasData(
           new Category
           {
               Id = 1,
               Name = "Electronics",
               Description = "Devices and gadgets"
           }
       );

            // Seed category 2
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 2,
                    Name = "Clothing",
                    Description = "Apparel and accessories"
                }
            );
            modelBuilder.Entity<Product>().HasData(
           new Product
           {
               Id = 1,
               Name = "Smartphone",
               Description = "Latest model smartphone",
               Price = 699.99m,
               UnitsInStock = 5000,
               CategoryID = 1
           }
       );

            // Seed product 2
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 2,
                    Name = "T-Shirt",
                    Description = "Cotton casual t-shirt",
                    Price = 19.99m,
                    UnitsInStock = 7500,
                    CategoryID = 2
                }
            );
        }


        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        
    }
    

    
}

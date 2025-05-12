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



            #region Seed Data
            // Users (unchanged)
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Username = "admin", // password :admin@123
                    Email = "admin@admin.com",
                    FirstName = "Admin",
                    LastName = "Admin",
                    Status = UserStatus.Admin,
                    IsActive = true,
                    DateCreated = DateTime.Parse("2025-05-11T00:00:00Z"),
                    DateUpdated = DateTime.Parse("2025-05-11T00:00:00Z"),
                    PasswordHash = "AQAAAAIAAYagAAAAECtJWIRqgoBEDzcFOu4Kz0LCY/MSge+0SZns5va/p5u6Gg4O87dz1beHha+iyFbsHA=="
                },
                new User
                {
                    Id = 2,
                    Username = "user", //password :user@123
                    Email = "user@user.com",
                    FirstName = "User",
                    LastName = "User",
                    Status = UserStatus.Client,
                    IsActive = true,
                    DateCreated = DateTime.Parse("2025-05-11T00:00:00Z"),
                    DateUpdated = DateTime.Parse("2025-05-11T00:00:00Z"),
                    PasswordHash = "AQAAAAIAAYagAAAAEBHDiyLRTxpFa9qgoSrzKlEMb2TQjBd1itcvuGrwgvtx80k7zeKga6KPH7+QO+522w=="
                },
                new User
                {
                    Id = 3,
                    Username = "admin2", // password :admin@123
                    Email = "superadmin@admin.com",
                    FirstName = "Super",
                    LastName = "Admin",
                    Status = UserStatus.Admin,
                    IsActive = true,
                    DateCreated = DateTime.Parse("2025-05-11T00:00:00Z"),
                    DateUpdated = DateTime.Parse("2025-05-11T00:00:00Z"),
                    PasswordHash = "AQAAAAIAAYagAAAAECtJWIRqgoBEDzcFOu4Kz0LCY/MSge+0SZns5va/p5u6Gg4O87dz1beHha+iyFbsHA=="
                },
                new User
                {
                    Id = 4,
                    Username = "user2", // password :user@123
                    Email = "jane@client.com",
                    FirstName = "Jane",
                    LastName = "Doe",
                    Status = UserStatus.Client,
                    IsActive = true,
                    DateCreated = DateTime.Parse("2025-05-11T00:00:00Z"),
                    DateUpdated = DateTime.Parse("2025-05-11T00:00:00Z"),
                    PasswordHash = "AQAAAAIAAYagAAAAEBHDiyLRTxpFa9qgoSrzKlEMb2TQjBd1itcvuGrwgvtx80k7zeKga6KPH7+QO+522w=="
                }
            );

            // Categories (unchanged)
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Electronics",
                    Description = "Devices and gadgets"
                },
                new Category
                {
                    Id = 2,
                    Name = "Clothing",
                    Description = "Apparel and accessories"
                },
                new Category
                {
                    Id = 3,
                    Name = "Books",
                    Description = "Fiction and non-fiction books"
                },
                new Category
                {
                    Id = 4,
                    Name = "Home & Kitchen",
                    Description = "Appliances and home goods"
                }
            );

            // Products (updated with new products)
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Smartphone",
                    Description = "Latest model smartphone",
                    Price = 699.99m,
                    UnitsInStock = 5000,
                    CategoryID = 1
                },
                new Product
                {
                    Id = 2,
                    Name = "T-Shirt",
                    Description = "Cotton casual t-shirt",
                    Price = 19.99m,
                    UnitsInStock = 7500,
                    CategoryID = 2
                },
                new Product
                {
                    Id = 3,
                    Name = "Laptop",
                    Description = "High-performance laptop",
                    Price = 1299.99m,
                    UnitsInStock = 2000,
                    CategoryID = 1
                },
                new Product
                {
                    Id = 4,
                    Name = "Jeans",
                    Description = "Denim blue jeans",
                    Price = 49.99m,
                    UnitsInStock = 6000,
                    CategoryID = 2
                },
                new Product
                {
                    Id = 5,
                    Name = "Sci-Fi Novel",
                    Description = "Best-selling science fiction book",
                    Price = 14.99m,
                    UnitsInStock = 10000,
                    CategoryID = 3
                },
                new Product
                {
                    Id = 6,
                    Name = "Cookbook",
                    Description = "Collection of gourmet recipes",
                    Price = 24.99m,
                    UnitsInStock = 8000,
                    CategoryID = 3
                },
                new Product
                {
                    Id = 7,
                    Name = "Blender",
                    Description = "High-speed kitchen blender",
                    Price = 89.99m,
                    UnitsInStock = 3000,
                    CategoryID = 4
                },
                new Product
                {
                    Id = 8,
                    Name = "Coffee Maker",
                    Description = "Programmable coffee machine",
                    Price = 59.99m,
                    UnitsInStock = 4000,
                    CategoryID = 4
                },
                new Product
                {
                    Id = 9,
                    Name = "Wireless Headphones",
                    Description = "Noise-cancelling over-ear headphones",
                    Price = 199.99m,
                    UnitsInStock = 3000,
                    CategoryID = 1
                },
                new Product
                {
                    Id = 10,
                    Name = "Smart Watch",
                    Description = "Fitness tracking smart watch",
                    Price = 249.99m,
                    UnitsInStock = 2500,
                    CategoryID = 1
                },
                new Product
                {
                    Id = 11,
                    Name = "Jacket",
                    Description = "Water-resistant winter jacket",
                    Price = 79.99m,
                    UnitsInStock = 4000,
                    CategoryID = 2
                },
                new Product
                {
                    Id = 12,
                    Name = "Sneakers",
                    Description = "Comfortable running sneakers",
                    Price = 69.99m,
                    UnitsInStock = 5000,
                    CategoryID = 2
                },
                new Product
                {
                    Id = 13,
                    Name = "Mystery Novel",
                    Description = "Gripping mystery thriller",
                    Price = 12.99m,
                    UnitsInStock = 12000,
                    CategoryID = 3
                },
                new Product
                {
                    Id = 14,
                    Name = "History Book",
                    Description = "Comprehensive world history text",
                    Price = 29.99m,
                    UnitsInStock = 7000,
                    CategoryID = 3
                },
                new Product
                {
                    Id = 15,
                    Name = "Air Fryer",
                    Description = "Multi-function air fryer",
                    Price = 119.99m,
                    UnitsInStock = 2000,
                    CategoryID = 4
                },
                new Product
                {
                    Id = 16,
                    Name = "Toaster Oven",
                    Description = "Compact toaster oven with multiple settings",
                    Price = 79.99m,
                    UnitsInStock = 3500,
                    CategoryID = 4
                }
            );

            // Orders (updated with new orders)
            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    OrderID = 1,
                    UserID = 1,
                    OrderDate = DateTime.Parse("2025-05-11T00:00:00Z"),
                    TotalAmount = 150.00m,
                    Status = OrderStatus.Pending,
                    DateProcessed = null
                },
                new Order
                {
                    OrderID = 2,
                    UserID = 2,
                    OrderDate = DateTime.Parse("2025-05-12T00:00:00Z"),
                    TotalAmount = 275.50m,
                    Status = OrderStatus.Approved,
                    DateProcessed = DateTime.Parse("2025-05-12T02:00:00Z")
                },
                new Order
                {
                    OrderID = 3,
                    UserID = 3,
                    OrderDate = DateTime.Parse("2025-05-13T00:00:00Z"),
                    TotalAmount = 739.97m,
                    Status = OrderStatus.Shipped,
                    DateProcessed = DateTime.Parse("2025-05-13T03:00:00Z")
                },
                new Order
                {
                    OrderID = 4,
                    UserID = 4,
                    OrderDate = DateTime.Parse("2025-05-14T00:00:00Z"),
                    TotalAmount = 104.97m,
                    Status = OrderStatus.Pending,
                    DateProcessed = null
                },
                new Order
                {
                    OrderID = 5,
                    UserID = 1,
                    OrderDate = DateTime.Parse("2025-05-15T00:00:00Z"),
                    TotalAmount = 1349.98m,
                    Status = OrderStatus.Approved,
                    DateProcessed = DateTime.Parse("2025-05-15T04:00:00Z")
                },
                new Order
                {
                    OrderID = 6,
                    UserID = 2,
                    OrderDate = DateTime.Parse("2025-05-16T00:00:00Z"),
                    TotalAmount = 99.97m,
                    Status = OrderStatus.Pending,
                    DateProcessed = null
                },
                new Order
                {
                    OrderID = 7,
                    UserID = 3,
                    OrderDate = DateTime.Parse("2025-05-17T00:00:00Z"),
                    TotalAmount = 164.96m,
                    Status = OrderStatus.Shipped,
                    DateProcessed = DateTime.Parse("2025-05-17T05:00:00Z")
                },
                new Order
                {
                    OrderID = 8,
                    UserID = 4,
                    OrderDate = DateTime.Parse("2025-05-18T00:00:00Z"),
                    TotalAmount = 29.98m,
                    Status = OrderStatus.Approved,
                    DateProcessed = DateTime.Parse("2025-05-18T06:00:00Z")
                },
                new Order
                {
                    OrderID = 9,
                    UserID = 1,
                    OrderDate = DateTime.Parse("2025-05-19T00:00:00Z"),
                    TotalAmount = 279.97m,
                    Status = OrderStatus.Pending,
                    DateProcessed = null
                },
                new Order
                {
                    OrderID = 10,
                    UserID = 2,
                    OrderDate = DateTime.Parse("2025-05-20T00:00:00Z"),
                    TotalAmount = 199.97m,
                    Status = OrderStatus.Approved,
                    DateProcessed = DateTime.Parse("2025-05-20T07:00:00Z")
                }
            );

            // OrderDetails (updated with new order details)
            modelBuilder.Entity<OrderDetail>().HasData(
                new OrderDetail
                {
                    Id = 1,
                    OrderID = 1,
                    ProductID = 1,
                    Quantity = 1
                },
                new OrderDetail
                {
                    Id = 2,
                    OrderID = 1,
                    ProductID = 2,
                    Quantity = 5
                },
                new OrderDetail
                {
                    Id = 3,
                    OrderID = 2,
                    ProductID = 3,
                    Quantity = 1
                },
                new OrderDetail
                {
                    Id = 4,
                    OrderID = 2,
                    ProductID = 4,
                    Quantity = 2
                },
                new OrderDetail
                {
                    Id = 5,
                    OrderID = 3,
                    ProductID = 1,
                    Quantity = 1
                },
                new OrderDetail
                {
                    Id = 6,
                    OrderID = 3,
                    ProductID = 7,
                    Quantity = 1
                },
                new OrderDetail
                {
                    Id = 7,
                    OrderID = 4,
                    ProductID = 5,
                    Quantity = 3
                },
                new OrderDetail
                {
                    Id = 8,
                    OrderID = 4,
                    ProductID = 8,
                    Quantity = 1
                },
                new OrderDetail
                {
                    Id = 9,
                    OrderID = 5,
                    ProductID = 3,
                    Quantity = 1
                },
                new OrderDetail
                {
                    Id = 10,
                    OrderID = 5,
                    ProductID = 2,
                    Quantity = 2
                },
                new OrderDetail
                {
                    Id = 11,
                    OrderID = 6,
                    ProductID = 4,
                    Quantity = 1
                },
                new OrderDetail
                {
                    Id = 12,
                    OrderID = 6,
                    ProductID = 8,
                    Quantity = 1
                },
                new OrderDetail
                {
                    Id = 13,
                    OrderID = 7,
                    ProductID = 7,
                    Quantity = 1
                },
                new OrderDetail
                {
                    Id = 14,
                    OrderID = 7,
                    ProductID = 6,
                    Quantity = 3
                },
                new OrderDetail
                {
                    Id = 15,
                    OrderID = 8,
                    ProductID = 5,
                    Quantity = 2
                },
                new OrderDetail
                {
                    Id = 16,
                    OrderID = 8,
                    ProductID = 2,
                    Quantity = 1
                },
                new OrderDetail
                {
                    Id = 17,
                    OrderID = 9,
                    ProductID = 9,
                    Quantity = 1
                },
                new OrderDetail
                {
                    Id = 18,
                    OrderID = 9,
                    ProductID = 11,
                    Quantity = 1
                },
                new OrderDetail
                {
                    Id = 19,
                    OrderID = 10,
                    ProductID = 10,
                    Quantity = 1
                },
                new OrderDetail
                {
                    Id = 20,
                    OrderID = 10,
                    ProductID = 12,
                    Quantity = 1
                }
            );

            // CartItems (updated with new cart items)
            modelBuilder.Entity<CartItem>().HasData(
                new CartItem
                {
                    Id = 1,
                    UserID = 1,
                    ProductID = 3,
                    Quantity = 1,
                    DateAdded = DateTime.Parse("2025-05-11T10:00:00Z")
                },
                new CartItem
                {
                    Id = 2,
                    UserID = 2,
                    ProductID = 5,
                    Quantity = 2,
                    DateAdded = DateTime.Parse("2025-05-12T12:00:00Z")
                },
                new CartItem
                {
                    Id = 3,
                    UserID = 3,
                    ProductID = 6,
                    Quantity = 1,
                    DateAdded = DateTime.Parse("2025-05-13T15:00:00Z")
                },
                new CartItem
                {
                    Id = 4,
                    UserID = 4,
                    ProductID = 7,
                    Quantity = 2,
                    DateAdded = DateTime.Parse("2025-05-14T09:00:00Z")
                },
                new CartItem
                {
                    Id = 5,
                    UserID = 1,
                    ProductID = 13,
                    Quantity = 2,
                    DateAdded = DateTime.Parse("2025-05-19T10:00:00Z")
                },
                new CartItem
                {
                    Id = 6,
                    UserID = 2,
                    ProductID = 15,
                    Quantity = 1,
                    DateAdded = DateTime.Parse("2025-05-20T12:00:00Z")
                },
                new CartItem
                {
                    Id = 7,
                    UserID = 3,
                    ProductID = 14,
                    Quantity = 1,
                    DateAdded = DateTime.Parse("2025-05-21T15:00:00Z")
                },
                new CartItem
                {
                    Id = 8,
                    UserID = 4,
                    ProductID = 16,
                    Quantity = 1,
                    DateAdded = DateTime.Parse("2025-05-22T09:00:00Z")
                }
            );
            
       
        }
    #endregion



        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        
    }
    

    
}

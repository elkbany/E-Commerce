using AdminTest;
using E_Commerce.BL.Contracts.Repositories;
using E_Commerce.BL.Contracts.Services;
using E_Commerce.BL.Features.User.DTOs;
using E_Commerce.BL.Features.User.Validators;
using E_Commerce.BL.Implementations;
using E_Commerce.DA.Context;
using E_Commerce.DA.Implementations.Repositories;
using E_Commerce.BL.Features.Order.Validators; // أضف الـ Namespace ده
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace E_Commerce.Presentation
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            var host = CreateHostBuilder().Build();
            ServiceProviderContainer.ServiceProvider = host.Services;
            Application.Run(new Start());
        }

        static IHostBuilder CreateHostBuilder() =>
           Host.CreateDefaultBuilder()
               .ConfigureServices((context, services) =>
               {
                   // Register DbContext with SQL Server
                   services.AddDbContext<DBContext>(options =>
                       options.UseSqlServer("Data Source=.;Initial Catalog=E-Commerce;Integrated Security=True;Trust Server Certificate=True;"));

                   var serviceProvider = services.BuildServiceProvider();
                   ServiceProviderContainer.ServiceProvider = serviceProvider;

                   // Register Forms
                   services.AddScoped<Login>();
                   services.AddScoped<Signup>();
                   services.AddScoped<frmMain>();
                   services.AddScoped<Admin>();
                   services.AddScoped<Start>();
                   services.AddScoped<frmProfile>();
                   services.AddScoped<frmChangePassword>();
                   services.AddScoped<frmProducts>();
                   services.AddScoped<frmOrders>();
                   services.AddScoped<frmOrderDetails>();

                   // Register Repositories
                   services.AddScoped<IProductRepository, ProductRepository>();
                   services.AddScoped<IUserRepository, UserRepository>();
                   services.AddScoped<IOrderRepository, OrderRepository>();
                   services.AddScoped<ICategoryRepository, CategoryRepository>();
                   services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
                   services.AddScoped<ICartItemRepository, CartItemRepository>();

                   // Register Services
                   services.AddScoped<IProductServices, ProductServices>();
                   services.AddScoped<IUserServices, UserServices>();
                   services.AddScoped<IOrderServices, OrderServices>();
                   services.AddScoped<ICategoryServices, CategoryServices>();
                   services.AddScoped<IOrderDetailServices, OrderDetailServices>();
                   services.AddScoped<ICartItemServices, CartItemServices>();
                   services.AddScoped<IAccountServices, AccountServices>();

                   // Register Validators
                   services.AddTransient<IValidator<RegisterUserDto>, RegisterUserDtoValidator>();
                   services.AddTransient<IValidator<LoginUserDto>, LoginUserDtoValidator>();
                   services.AddTransient<IValidator<int>, OrderIdValidator>(); // أضف تسجيل الـ Validator ده
               });
    }
}
using E_Commerce.BL.Contracts.Repositories;
using E_Commerce.BL.Contracts.Services;
using E_Commerce.BL.Features.User.DTOs;
using E_Commerce.BL.Features.User.Validators;
using E_Commerce.BL.Implementations;
using E_Commerce.DA.Context;
using E_Commerce.DA.Implementations.Repositories;
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
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            var host = CreateHostBuilder().Build();
            ServiceProviderContainer.ServiceProvider = host.Services;
            var signUpForm = host.Services.GetRequiredService<Signup>();
            var loginForm = host.Services.GetRequiredService<Login>();
            Application.Run(loginForm);
            //Application.Run(new Login());
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
              
                   // Register Form1 (and other forms or services you need)
                   services.AddScoped<Login>();
                   services.AddScoped<Signup>();
                  
                   // Register your repositories and services here
                   services.AddScoped<IProductRepository, ProductRepository>();
                   services.AddScoped<IProductServices, ProductServices>();
                   services.AddScoped<IUserRepository, UserRepository>();
                   services.AddScoped<IUserServices, UserServices>();
                   services.AddScoped<IOrderRepository, OrderRepository>();
                   services.AddScoped<IOrderServices, OrderServices>();
                   services.AddScoped<ICategoryRepository, CategoryRepository>();
                   services.AddScoped<ICategoryServices, CategoryServices>();
                   services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
                   services.AddScoped<IOrderDetailServices, OrderDetailServices>();
                 
                   services.AddScoped<IAccountServices, AccountServices>();
                   services.AddTransient<IValidator<RegisterUserDto>, RegisterUserDtoValidator>();

               });
    }
}
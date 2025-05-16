using E_Commerce.BL.Configurations; // أضف Namespace ده لو فيه ملف ProductMappingConfig
using E_Commerce.BL.Contracts.Repositories;
using E_Commerce.BL.Contracts.Services;
using E_Commerce.BL.Features.User.DTOs;
using E_Commerce.BL.Features.User.Validators;
using E_Commerce.BL.Implementations;
using E_Commerce.DA.Context;
using E_Commerce.DA.Implementations.Repositories;
using E_Commerce.BL.Features.Order.Validators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows.Forms;
using Microsoft.Extensions.Logging;
using E_Commerce.BL.Features.Product.DTOs;
using E_Commerce.BL.Features.Product.Validators;
using E_Commerce.BL.Features.Category.DTOs;
using E_Commerce.BL.Features.Category.Validators;
using E_Commerce.BL.Mapping;

namespace E_Commerce.Presentation
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            var host = CreateHostBuilder().Build();
            ServiceProviderContainer.ServiceProvider = host.Services;

            var startForm = ServiceProviderContainer.ServiceProvider.GetRequiredService<Start>();
            Application.Run(startForm);
        }

        static IHostBuilder CreateHostBuilder() =>
            Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    // Register DbContext with SQL Server
                    services.AddDbContext<DBContext>(options =>
                        options.UseSqlServer("Data Source=.;Initial Catalog=E-Commerce;Integrated Security=True;Trust Server Certificate=True;MultipleActiveResultSets=true"));

                    // Register Forms
                    services.AddScoped<Start>();
                    services.AddScoped<Login>();
                    services.AddScoped<Signup>();
                    services.AddScoped<frmMain>();
                    services.AddScoped<Admin>();
                    services.AddScoped<frmProfile>();
                    services.AddScoped<frmChangePassword>();
                    services.AddScoped<frmProducts>();
                    services.AddScoped<frmOrders>();
                    services.AddScoped<frmOrderDetails>();
                    services.AddScoped<frmCart>();
                    services.AddScoped<CategoriesPage>();
                    services.AddTransient<ProductsPage>();
                    services.AddTransient<AddForm>();



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
                    services.AddTransient<IValidator<int>, OrderIdValidator>();
                    services.AddTransient<IValidator<AddProductDTO>, ProductDTOValidator>();

                    // Register Mapster Mapping Configuration
                    ProductMappingConfig.Configure();
                    CategoryMappingConfig.Configure();


                });
    }
}
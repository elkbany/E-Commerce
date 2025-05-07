using E_Commerce.DA.Context;
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
            Application.Run(new Form1());
        }
        static IHostBuilder CreateHostBuilder() =>
           Host.CreateDefaultBuilder()
               .ConfigureServices((context, services) =>
               {
                   // Register DbContext with SQL Server
                   services.AddDbContext<DBContext>(options =>
                       options.UseSqlServer("Data Source=.;Initial Catalog=E-Commerce;Integrated Security=True;Trust Server Certificate=True;"));

                   // Register Form1 (and other forms or services you need)
                   services.AddScoped<Form1>();

                   // Register your repositories and services here
                   // services.AddScoped<IProductRepository, ProductRepository>();
                   // services.AddScoped<IProductServices, ProductServices>();
               });
    }
}
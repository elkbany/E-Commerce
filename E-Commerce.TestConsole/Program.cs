using E_Commerce.BL.Contracts.Repositories;
using E_Commerce.BL.Contracts.Services;
using E_Commerce.BL.Implementations;
using E_Commerce.BL.Validators;
using E_Commerce.DA.Implementations.Repositories;
using E_Commerce.DA.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using FluentValidation;

namespace E_Commerce.TestConsole
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // إعداد Dependency Injection
            var serviceProvider = new ServiceCollection()
                .AddDbContext<DBContext>(options =>
                    options.UseSqlServer("Data Source=.;Initial Catalog=E-Commerce;Integrated Security=True;Trust Server Certificate=True;"))
                .AddScoped<IOrderRepository, OrderRepository>()
                .AddScoped<IOrderServices, OrderServices>()
                .AddScoped<IValidator<int>, OrderDTOValidator>()
                .BuildServiceProvider();

            // جيب الـ Service
            var orderServices = serviceProvider.GetService<IOrderServices>();

            // جرب ApproveOrderAsync
            Console.WriteLine("Enter Order ID to Approve:");
            if (int.TryParse(Console.ReadLine(), out int orderId))
            {
                var result = await orderServices.ApproveOrderAsync(orderId);
                Console.WriteLine($"Success: {result.Success}, Message: {result.Message}");
                if (result.Data != null)
                {
                    Console.WriteLine($"Order ID: {result.Data.OrderID}, Status: {result.Data.Status}");
                }
            }
            else
            {
                Console.WriteLine("Invalid Order ID.");
            }

            Console.WriteLine("Press any key to exit...");
        }
    }
}
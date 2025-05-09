using E_Commerce.BL.Contracts.Repositories;
using E_Commerce.BL.Features.Order.DTOs;
using E_Commerce.Domain.Enums;
using E_Commerce.Domain.Models;
using FluentValidation;
using System.Threading.Tasks;

namespace E_Commerce.BL.Validators
{
    public class OrderDTOValidator : AbstractValidator<OrderDTO>
    {

        public OrderDTOValidator()
        {
            RuleFor(order => order.UserID)
            .GreaterThan(0)
            .WithMessage("User ID must be greater than 0.");

            RuleFor(order => order.OrderDate)
                .NotEmpty()
                .WithMessage("Order Date is required.");

            RuleFor(order => order.TotalAmount)
                .GreaterThan(0)
                .WithMessage("Total Amount must be greater than 0.");
        }

    }
}
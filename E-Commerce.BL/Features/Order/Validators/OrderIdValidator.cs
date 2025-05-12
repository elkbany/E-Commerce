using FluentValidation;

namespace E_Commerce.BL.Features.Order.Validators
{
    public class OrderIdValidator : AbstractValidator<int>
    {
        public OrderIdValidator()
        {
            RuleFor(id => id).GreaterThan(0).WithMessage("Order ID must be greater than 0.");
        }
    }
}
using E_Commerce.BL.Features.CartItem.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BL.Features.CartItem.Validators
{
    public class AddCartItemDTOValidator : AbstractValidator<AddCartItemDTO>
    {
        public AddCartItemDTOValidator()
        {
            RuleFor(x => x.UserId).GreaterThan(0).WithMessage("User ID must be greater than 0.");
            RuleFor(x => x.ProductId).GreaterThan(0).WithMessage("Product ID must be greater than 0.");
            RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("Quantity must be greater than 0.");
        }
    }
}

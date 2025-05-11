using E_Commerce.BL.Features.CartItem.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BL.Features.CartItem.Validators
{
    public class UpdateCartItemQuantityDTOValidator : AbstractValidator<UpdateCartItemQuantityDTO>
    {
        public UpdateCartItemQuantityDTOValidator()
        {
            RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("Quantity must be greater than 0.");
        }
    }
}

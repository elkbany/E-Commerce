using E_Commerce.BL.Features.User.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BL.Features.User.Validators
{
    public class UpdateUserAccountDTOValidator : AbstractValidator<UpdateUserAccountDTO>
    {
        public UpdateUserAccountDTOValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First Name is required.");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last Name is required.");
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("A valid email is required.");
            //RuleFor(x => x.Password).MinimumLength(6).When(x => !string.IsNullOrWhiteSpace(x.Password)).WithMessage("Password must be at least 6 characters long.");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce.BL.Features.User.DTOs;
using FluentValidation;

namespace E_Commerce.BL.Features.User.Validators
{
    class UserDTOValidtor: AbstractValidator<UserDTO>
    {
        public UserDTOValidtor()
        {
            RuleFor(U => U.Username)
            .NotEmpty().WithMessage("Username is required")
            .Length(3, 30).WithMessage("Username must be 3-30 characters")
            .Matches(@"^[a-zA-Z0-9_]+$").WithMessage("Username can only contain letters, numbers, and underscores");

            RuleFor(U=>U.FirstName)
                .NotEmpty().WithMessage("Frist Name is required!")
            .Length(3,10).WithMessage("Name must be 3-10 characters!");

            RuleFor(U => U.LastName)
                .NotEmpty().WithMessage("Last Name is required!")
            .Length(3, 10).WithMessage("Name must be 3-10 characters!");

            RuleFor(U=> U.Password)
           .NotEmpty().WithMessage("Password is required")
           .MinimumLength(8).WithMessage("Password must be at least 8 characters")
           .Matches("[A-Z]").WithMessage("Password must contain at least 1 uppercase letter")
           .Matches("[a-z]").WithMessage("Password must contain at least 1 lowercase letter")
           .Matches("[0-9]").WithMessage("Password must contain at least 1 number")
           .Matches("[^a-zA-Z0-9]").WithMessage("Password must contain at least 1 special character");

            RuleFor(U => U.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Invalid email format")
            .Must(email => !email.EndsWith("@temp-mail.org")).WithMessage("Disposable emails are not allowed");

        }

    }
}

using E_Commerce.BL.Contracts.Repositories;
using E_Commerce.BL.Features.User.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BL.Features.User.Validators
{
    public class RegisterUserDtoValidator : AbstractValidator<RegisterUserDto>
    {
        private readonly IUserRepository userRepository;

        public RegisterUserDtoValidator(IUserRepository userRepository ) 
        {
            this.userRepository = userRepository;

            RuleFor(x => x.Username)
                .NotEmpty()
                .WithMessage("Username is required.")
                .Length(3, 20)
                 .WithMessage("Username must be between 3 and 20 characters.")
                .MustAsync(async (username, cancellation) =>
                      !await userRepository.IsUsernameTakenAsync(username))
                .WithMessage("This Username is exists , Your username must be unique.");
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email is required.")
                .EmailAddress()
                .WithMessage("Invalid email format.")
                 .MustAsync(async (email, cancellation) =>
                      !await userRepository.IsEmailAlreadyExistsAsync(email))
                .WithMessage("This Email Address is already registered");
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("First name is required.")
                .Length(2, 50)
                .WithMessage("First name must be between 2 and 50 characters.");
            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("Last name is required.")
                .Length(2, 50)
                .WithMessage("Last name must be between 2 and 50 characters.");
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password is required.")
                .MinimumLength(6)
                .WithMessage("Password must be at least 6 characters long.");
            RuleFor(x => x.ConfirmPassword)
                .Equal(x => x.Password)
                .WithMessage("Passwords do not match.");
        }
    }
}

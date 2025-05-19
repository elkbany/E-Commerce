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
    public class UserDTOValidator : AbstractValidator<UserDTO>
    {
        private readonly IUserRepository userRepository;

        public UserDTOValidator(IUserRepository userRepository)
        {
            this.userRepository = userRepository;

            RuleFor(x => x.Username)
                .NotEmpty()
                .WithMessage("Username is required.")
                .Length(3, 20)
                .WithMessage("Username must be between 3 and 20 characters.")
                .MustAsync(async (username, cancellation) =>
                    !await userRepository.IsUsernameTakenAsync(username))
                .WithMessage("This Username is already taken. Your username must be unique.");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email is required.")
                .EmailAddress()
                .WithMessage("Invalid email format.")
            .MustAsync(async (email, cancellation) =>
                    !await userRepository.IsEmailAlreadyExistsAsync(email))
                .WithMessage("This Email Address is already registered.");
        }
    }
}

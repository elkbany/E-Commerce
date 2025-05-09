
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
    public class loginUserDtoValidator : AbstractValidator<LoginUserDto>
    {
        private readonly IUserRepository userRepository;

        public loginUserDtoValidator(IUserRepository userRepository) 
        {
            this.userRepository = userRepository;
            RuleFor(x => x.Username)
                 .NotEmpty()
                 .WithMessage("Username is required.")
                 .Length(3, 20)
                 .WithMessage("Username must be between 3 and 20 characters.")
                 .MustAsync(async (username, cancellation) =>
                     await userRepository.IsUsernameTakenAsync(username))
                 .WithMessage("Username does not exist.");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password is required.")
                .MinimumLength(6)
                .WithMessage("Password must be at least 6 characters long.");

        }
    }
}

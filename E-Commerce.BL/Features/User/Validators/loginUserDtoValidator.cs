using E_Commerce.BL.Contracts.Repositories;
using E_Commerce.BL.Features.User.DTOs;
using E_Commerce.Domain.Models;
using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace E_Commerce.BL.Features.User.Validators
{
    public class LoginUserDtoValidator : AbstractValidator<LoginUserDto>
    {
        public LoginUserDtoValidator()
        {
            RuleFor(x => x.UsernameOrEmail)
                .NotEmpty().WithMessage("Username/Email is required.")
                .MaximumLength(100).WithMessage("Username/Email must not exceed 100 characters.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long.")
                .MaximumLength(100).WithMessage("Password must not exceed 100 characters.");
        }
    }
}

//using E_Commerce.BL.Contracts.Repositories;
//using E_Commerce.BL.Features.User.DTOs;
//using E_Commerce.Domain.Models;
//using FluentValidation;
//using Microsoft.AspNetCore.Identity;

//namespace E_Commerce.BL.Implementations.Validators
//{
//    public class LoginUserDtoValidator : AbstractValidator<LoginUserDto>
//    {
//        private readonly IUserRepository userRepository;
//        private readonly IPasswordHasher<User> passwordHasher;

//        public LoginUserDtoValidator(IUserRepository userRepository, IPasswordHasher<User> passwordHasher)
//        {
//            this.userRepository = userRepository;
//            this.passwordHasher = passwordHasher;

//            RuleFor(x => x.UsernameOrEmail)
//                .NotEmpty().WithMessage("Username/Email is required.")
//                .MaximumLength(100).WithMessage("Username/Email must not exceed 100 characters.")
//                .MustAsync(async (usernameOrEmail, cancellation) => await BeValidUserAsync(usernameOrEmail))
//                .WithMessage("Username/Email does not exist.");

//            RuleFor(x => x.Password)
//                .NotEmpty().WithMessage("Password is required.")
//                .MinimumLength(6).WithMessage("Password must be at least 6 characters long.")
//                .MaximumLength(100).WithMessage("Password must not exceed 100 characters.")
//                .MustAsync(async (dto, password, cancellation) => await BeValidPasswordAsync(dto.UsernameOrEmail, password))
//                .WithMessage("Incorrect password.");
//        }

//        private async Task<bool> BeValidUserAsync(string usernameOrEmail)
//        {
//            var user = await userRepository.FirstOrDefaultAsync(u => u.Username == usernameOrEmail || u.Email == usernameOrEmail);
//            return user != null;
//        }

//        private async Task<bool> BeValidPasswordAsync(string usernameOrEmail, string password)
//        {
//            var user = await userRepository.FirstOrDefaultAsync(u => u.Username == usernameOrEmail || u.Email == usernameOrEmail);
//            if (user == null) return false;
//            return passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password) == PasswordVerificationResult.Success;
//        }
//    }
//}
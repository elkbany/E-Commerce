using E_Commerce.BL.Contracts.Repositories;
using E_Commerce.BL.Features.Product.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BL.Features.Product.Validators
{
    public class ProductDTOValidator : AbstractValidator<AddProductDTO>
    {
        private readonly IProductRepository productRepository;

        public ProductDTOValidator(IProductRepository productRepository)
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("You must type the product name");
            //checl if the name of the product is unique
            RuleFor(p => p.Name)
                .MustAsync(async (name, cancellation) =>
                    !await productRepository.IsProductNameExistsAsync(name))
                .WithMessage("This product name is already taken. Your product name must be unique.");
            this.productRepository = productRepository;
        }
    }
}

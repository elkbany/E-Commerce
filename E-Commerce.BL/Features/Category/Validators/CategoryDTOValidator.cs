using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce.BL.Features.Category.DTOs;
using FluentValidation;

namespace E_Commerce.BL.Features.Category.Validators
{
    public class CategoryDTOValidator : AbstractValidator<CategoryDTO>
    {
        public CategoryDTOValidator() 
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("You must type the category name");
        }
    }
}

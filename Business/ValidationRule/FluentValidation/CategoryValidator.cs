using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRule.FluentValidation
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(c => c.CategoryName)
                .NotEmpty().WithMessage("Category name cannot be empty.")
                .NotNull().WithMessage("Category name cannot be null.")
                .MinimumLength(3).WithMessage("Category name must contain at least three characters.")
                .Matches(@"^[^0-9!@#$%^&*()_+|~=`{}\[\]:\"" ;'<>?,./]+$")
                .WithMessage("Category name can only contain letters and some special characters.");

            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("Description cannot be empty.")
                .NotNull().WithMessage("Description cannot be null.")
                .MinimumLength(3).WithMessage("Description must contain at least three characters.")
                .Matches(@"^[^!@#$%^&*()_+|~=`{}\[\]:\"" ;'<>?,./]+$")
                .WithMessage("Description can only contain letters and some special characters.");
        }
    }


}

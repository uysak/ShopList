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
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.ProductName)
                .NotEmpty().WithMessage("Product name cannot be empty.")
                .Matches("^[a-zA-Z0-9]*$").WithMessage("Product name can only contain letters and numbers.");

            RuleFor(x => x.Description)
                .Matches("^[a-zA-Z0-9]*$").WithMessage("Description can only contain letters and numbers.");
        }

    }

}

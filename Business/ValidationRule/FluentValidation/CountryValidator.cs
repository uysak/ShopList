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
    public class CountryValidator : AbstractValidator<Country>
    {
        public CountryValidator()
        {
            RuleFor(x => x.CountryName)
                .NotEmpty().WithMessage("Country name is required.");

            RuleFor(x => x.FlagImgLink)
                .NotEmpty().WithMessage("Flag link is required.")
                .Matches(@"^http(s)?://([\w-]+.)+[\w-]+(/[\w- ./?%&=])?$")
                .WithMessage("Please enter a valid URL.");
        }
    }
}

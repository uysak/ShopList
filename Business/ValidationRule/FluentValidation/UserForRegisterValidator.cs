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
    public class UserForRegisterValidator : AbstractValidator<User>
    {
        public UserForRegisterValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().MaximumLength(50)
                .Matches(@"^[^0-9!@#$%^&*()_+|~=`{}\[\]:\"" ;'<>?,./]+$")
                .WithMessage("First name can only contain letters and some special characters.");

            RuleFor(x => x.LastName).NotEmpty().MaximumLength(50)
                .Matches(@"^[^0-9!@#$%^&*()_+|~=`{}\[\]:\"" ;'<>?,./]+$")
                .WithMessage("Last name can only contain letters and some special characters.");

            RuleFor(x => x.CountryCode).NotEmpty().InclusiveBetween(1, 999);

            RuleFor(x => x.Email).NotEmpty().EmailAddress();

        }
    }


}

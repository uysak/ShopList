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
    public class StatusValidator : AbstractValidator<Status>
    {
        public StatusValidator()
        {
            RuleFor(x => x.StatusName)
                .NotNull().WithMessage("Status name cannot be null")
                .NotEmpty().WithMessage("Status name cannot be empty")
                .Matches(@"^[^0-9!@#$%^&*()_+|~=`{}\[\]:\"" ;'<>?,./]+$")
                .WithMessage("StatusName can only contain letters and some special characters.");

            RuleFor(x => x.StatusDescription)
                .Matches(@"^[^0-9!@#$%^&*()_+|~=`{}\[\]:\"" ;'<>?,./]+$")
                .WithMessage("StatusDescription can only contain letters and some special characters.");
        }
    }



}

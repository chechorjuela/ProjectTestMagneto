using EldenLabs.Application.Core.Dto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EldenLabs.Application.Core.Validation
{
    public class SignUpValidator : AbstractValidator<SignUpRequestDto>
    {
        public SignUpValidator()
        {
            RuleFor(a => a.UserName).NotEmpty().WithMessage("The usernamne is required.");
            RuleFor(a => a.Password).NotEmpty().WithMessage("The password is required.");

        }
    }
}

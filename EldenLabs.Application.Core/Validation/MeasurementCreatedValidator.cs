using EldenLabs.Application.Core.Dto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EldenLabs.Application.Core.Validation
{
    public class MeasurementCreatedValidator : AbstractValidator<MeasurementRequestDto>
    {
        public MeasurementCreatedValidator() {
            RuleFor(a => a.HefestoId).NotEmpty().WithMessage("The HefestoId is required.");
        }
    }
}

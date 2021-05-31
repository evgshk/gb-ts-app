using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Infrastructure.Constants;
using Timesheets.Models.Dto;

namespace Timesheets.Infrastructupe.Validation
{
    public class InvoiceRequestValidator : AbstractValidator<InvoiceRequest>
    {
        public InvoiceRequestValidator()
        {
            RuleFor(x => x.ContractId).NotEmpty();

            RuleFor(x => x.DateStart)
                .LessThanOrEqualTo(x => x.DateEnd)
                .WithMessage(ValidationMessages.InvoiceRequestDateError);

            RuleFor(x => x.DateEnd)
                .GreaterThanOrEqualTo(x => x.DateStart)
                .WithMessage(ValidationMessages.InvoiceRequestDateError);
        }
    }
}

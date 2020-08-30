using Accounting.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Accounting.Application.GeneralLedgers.Commands.CreateCommand
{
    public class CreateGeneralLedgerCommandValidator : AbstractValidator<CreateGeneralLedgerCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateGeneralLedgerCommandValidator(IApplicationDbContext context)
        {
            _context = context;      

            RuleFor(v => v.GLNameAr)
                .NotEmpty().WithMessage("General Ledger Name (Ar) is required")
                .MaximumLength(250).WithMessage("General Ledger Name (Ar) can not exceed 250 characters");

            RuleFor(v => v.GlNameEn)
                .MaximumLength(250).WithMessage("General Ledger Name (En) can not exceed 250 characters");

            RuleFor(v => v.CustomerId)
                .NotEmpty().WithMessage("Customer Id can't be null")
                .MustAsync(BeExistCustomer).WithMessage("Invalid Customer");
        }

        private async Task<bool> BeExistCustomer(Guid customerId, CancellationToken cancellationToken)
        {
            var result = await _context.Customers.AnyAsync(c => c.Id == customerId);
            return result;
        }
    }
}

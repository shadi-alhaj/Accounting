using Accounting.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Accounting.Application.Bonds.Commands.CreateCommand
{
    public class CreateBondCommandValidator : AbstractValidator<CreateBondCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateBondCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.IntialSNo)
                .GreaterThan(0).WithMessage("Bond Intial SNo should be greater than 0");

            RuleFor(v => v.BondNameAr)
                .NotEmpty().WithMessage("Bond Name (Ar) is required")
                .MaximumLength(250).WithMessage("Bond Name (Ar) can not exceed 250 characters");

            RuleFor(v => v.BondNameEn)
                .MaximumLength(250).WithMessage("Bond Name (En) can not exceed 250 characters");

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

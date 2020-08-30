using Accounting.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Accounting.Application.TotalAccounts.Commands.CreateCommand
{
    public class CreateTotalAccountCommandValidator : AbstractValidator<CreateTotalAccountCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateTotalAccountCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.TotalAccountIdByCustomer)
                .NotEmpty().WithMessage("Total Account Id can't be empty")
                .GreaterThan(0).WithMessage("Total Account Id can't Zero or negative");

            RuleFor(v => v.TotalAccountNameAr)
                .NotEmpty().WithMessage("Total Account Name (Ar) can't be empty")
                .MaximumLength(250).WithMessage("Total Account Name (Ar) can't exceed 250 characters");

            RuleFor(v => v.TotalAccountNameEn)
                .MaximumLength(250).WithMessage("Total Account Name (En) can't exceed 250 characters");

            RuleFor(v => v.CustomerId)
              .NotEmpty().WithMessage("Customer Id can't be null")
              .MustAsync(BeExistCustomer).WithMessage("Invalid Customer");

            RuleFor(v => v.MainAccountId)
                .NotEmpty().WithMessage("Total account must belong to Main Account")
                .MustAsync(BeExistGLForThisCustomer).WithMessage("The Main account not defined for this customer");
            
        }

        private async Task<bool> BeExistGLForThisCustomer(CreateTotalAccountCommand command, Guid mainAccountId, CancellationToken cancellationToken)
        {
            var result = await _context.MainAccounts.AnyAsync(m => m.CustomerId == command.CustomerId && m.Id == mainAccountId && m.IsActive);
            return result;
        }

        private async Task<bool> BeExistCustomer(Guid customerId, CancellationToken cancellationToken)
        {
            var result = await _context.Customers.AnyAsync(c => c.Id == customerId);
            return result;
        }
    }
}

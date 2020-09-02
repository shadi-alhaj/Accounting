using Accounting.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Accounting.Application.DetailAccounts.Commands.CreateCommand
{
    public class CreateDetailAccountCommandValidator : AbstractValidator<CreateDetailAccountCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateDetailAccountCommandValidator(IApplicationDbContext context)
        {
            this._context = context;
            RuleFor(v => v.DetailAccountIdByCustomer)
                .NotEmpty().WithMessage("Detail Account Id can't be empty")
                .GreaterThan(0).WithMessage("Detail Account Id can't Zero or negative");

            RuleFor(v => v.DetailAccountNameAr)
                .NotEmpty().WithMessage("Detail Account Name (Ar) can't be empty")
                .MaximumLength(250).WithMessage("Detail Account Name (Ar) can't exceed 250 characters");

            RuleFor(v => v.DetailAccountNameEn)
                .MaximumLength(250).WithMessage("Detail Account Name (En) can't exceed 250 characters");

            RuleFor(v => v.CustomerId)
              .NotEmpty().WithMessage("Customer Id can't be null")
              .MustAsync(BeExistCustomer).WithMessage("Invalid Customer");

            RuleFor(v => v.TotalAccountId)
                .NotEmpty().WithMessage("Detail Account must belong to Total Account")
                .MustAsync(BeExistGLForThisCustomer).WithMessage("The Main account not defined for this customer");

        }

        private async Task<bool> BeExistGLForThisCustomer(CreateDetailAccountCommand command, Guid mainAccountId, CancellationToken cancellationToken)
        {
            var result = await _context.TotalAccounts.AnyAsync(m => m.CustomerId == command.CustomerId && m.Id == mainAccountId && m.IsActive);
            return result;
        }

        private async Task<bool> BeExistCustomer(Guid customerId, CancellationToken cancellationToken)
        {
            var result = await _context.Customers.AnyAsync(c => c.Id == customerId);
            return result;
        }
    }
}

using Accounting.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Accounting.Application.MainAccounts.Commands.CreateCommand
{
    public class CreateMainAccountCommandValidator : AbstractValidator<CreateMainAccountCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateMainAccountCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.MainAccountIdByCustomer)
                .NotEmpty().WithMessage("Main Account Id can't be empty")
                .GreaterThan(0).WithMessage("Main Account Id can't Zero or negative");

            RuleFor(v => v.MainAccountNameAr)
                .NotEmpty().WithMessage("Main Account Name (Ar) can't be empty")
                .MaximumLength(250).WithMessage("Main Account Name (Ar) can't exceed 250 characters");

            RuleFor(v => v.MainAccountNameEn)
                .MaximumLength(250).WithMessage("Main Account Name (En) can't exceed 250 characters");

            RuleFor(v => v.CustomerId)
              .NotEmpty().WithMessage("Customer Id can't be null")
              .MustAsync(BeExistCustomer).WithMessage("Invalid Customer");

            RuleFor(v => v.GeneralLeadgerId)
                .NotEmpty().WithMessage("Main account must belong to General Account")
                .MustAsync(BeExistGLForThisCustomer).WithMessage("The General not defined for this customer");
        }

        private async Task<bool> BeExistGLForThisCustomer(CreateMainAccountCommand command,Guid generalLedgerId, CancellationToken cancellationToken)
        {
            var result = await _context.GeneralLedgers.AnyAsync(g => g.CustomerId == command.CustomerId && g.Id == generalLedgerId && g.IsActive);
            return result;
        }

        private async Task<bool> BeExistCustomer(Guid customerId, CancellationToken cancellationToken)
        {
            var result = await _context.Customers.AnyAsync(c => c.Id == customerId);
            return result;
        }
    }
}

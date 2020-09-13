using Accounting.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Accounting.Application.DailyTransactions.Commands.CreateCommand
{
    public class CreateDailyTransactionCommandValidator : AbstractValidator<CreateDailyTransactionCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateDailyTransactionCommandValidator(IApplicationDbContext context)
        {
            _context = context;
            RuleFor(v => v.DailyTransactionBondSNo)
                .NotEmpty().WithMessage("Bond SNo can't be empty")
                .GreaterThan(0).WithMessage("Bond SNo can't be zero or negative");

            RuleFor(v => v.CustomerId)
                .NotEmpty().WithMessage("Customer Id can't be null")
                .MustAsync(BeExistCustomer).WithMessage("Invalid Customer");

            RuleFor(v => v.BondId)
                .NotEmpty().WithMessage("Bond Id can't be null")
                .MustAsync(BeExistBond).WithMessage("Invalid Bond Id");

            RuleFor(v => v.DailyTransactionDate)
                .Must(BeDateInFinanceYear).WithMessage("Invalid transaction date!. The transaction date should be in the same finance year.");
        }


        private  bool BeDateInFinanceYear(CreateDailyTransactionCommand command,DateTime dailyTransactionDate)
        {
            var result = command.DailyTransactionYear == dailyTransactionDate.Year;
            return result;
        }

        private async Task<bool> BeExistBond(Guid bondId, CancellationToken cancellationToken)
        {
            var result = await _context.Bonds.AnyAsync(b => b.Id == bondId);
            return result;
        }

        private async Task<bool> BeExistCustomer(Guid customerId, CancellationToken cancellationToken)
        {
            var result = await _context.Customers.AnyAsync(c => c.Id == customerId);
            return result;
        }
    }
}

using Accounting.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
                .NotEmpty().WithMessage("Customer Id can't be empty")
                .MustAsync(BeExistCustomer).WithMessage("Invalid Customer");

            RuleFor(v => v.BondId)
                .NotEmpty().WithMessage("Bond Id can't be empty")
                .MustAsync(BeExistBond).WithMessage("Invalid Bond Id");

            RuleFor(v => v.DailyTransactionDate)
                .Must(BeDateInFinanceYear).WithMessage("Invalid transaction date!. The transaction date should be in the same finance year.");

            RuleFor(v => v.DailyTransactionMonth)
                .NotEmpty().WithMessage("Daily Transaction month can't be empty")
                .GreaterThan(0).WithMessage("Daily Transaction month should be greater than zero")
                .LessThan(13).WithMessage("Daily Transaction month should be less than or equal 12");

            RuleFor(v => v.DailyTransactionDetailsList)
                .ForEach(d =>
                {
                    d.Must(BeDebitOrCredit).WithMessage("Daily Transaction should be a debit or credit only");
                })
                .MustAsync(BeExistDetailAccount).WithMessage("Daily Transaction should belong to a defined details account")
                .Must(BeEqualDebitCredit).WithMessage("Debit and Credit Amount are not Equal");

           
        }

        private bool BeEqualDebitCredit(IEnumerable<CreateDailyTransactionCommand.DailyTransactionDetailsDto> dailyTransactionDetailsDtos)
        {
            decimal totalDebit = 0.0m;
            decimal totalCredit = 0.0m;

            foreach (var item in dailyTransactionDetailsDtos)
            {
                if (item.DailyTransactionDebitAmount > item.DailyTransactionCreditAmount)
                {
                    totalDebit += item.DailyTransactionDebitAmount;
                }
                else if (item.DailyTransactionCreditAmount > item.DailyTransactionDebitAmount)
                {
                    totalCredit += item.DailyTransactionCreditAmount;
                }
                else
                {
                    return false;
                }
            }

            if (totalDebit != totalCredit)
                return false;

            return true;
        }

        private async Task<bool> BeExistDetailAccount(CreateDailyTransactionCommand command, IEnumerable<CreateDailyTransactionCommand.DailyTransactionDetailsDto> dailyTransactionDetailsDtos, CancellationToken cancellationToken)
        {
            var result = true;
            foreach (var item in dailyTransactionDetailsDtos)
            {
                result = await _context.DetailAccounts.AnyAsync(d => d.CustomerId == command.CustomerId && d.Id == item.DetailAccountId);
                if (!result)
                    return result;
            }

            return result;
        }


        private bool BeDebitOrCredit(CreateDailyTransactionCommand.DailyTransactionDetailsDto dailyTransactionDetailsDto)
        {
            var result = true;
            if (dailyTransactionDetailsDto.DailyTransactionDebitAmount != 0 && dailyTransactionDetailsDto.DailyTransactionCreditAmount != 0)
                result = false;
            else if (dailyTransactionDetailsDto.DailyTransactionDebitAmount == 0 && dailyTransactionDetailsDto.DailyTransactionCreditAmount == 0)
                result = false;

            return result;
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

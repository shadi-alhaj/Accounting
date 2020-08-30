using Accounting.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Accounting.Application.FinanceYears.Commands.CreateCommand
{
    public class CreateFinanceYearCommandValidator : AbstractValidator<CreateFinanceYearCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateFinanceYearCommandValidator(IApplicationDbContext context)
        {
            _context = context;
            int year = 1980;
            int currentYear = DateTime.Now.Year +1;
            RuleFor(v => v.CustomerId)
                 .NotEmpty().WithMessage("Customer Id can't be null")
                 .MustAsync(BeExistCustomer).WithMessage("Invalid Customer");

            RuleFor(v => v.Year)
                .NotEmpty().WithMessage("Finance Year can not be empty")
                .LessThan(currentYear).WithMessage($"The Finance year should not be in the future")
                .GreaterThan(year).WithMessage($"The Finance year should be greater than {year}")
                .MustAsync(BeUniqueFinanceYear).WithMessage("The finance year already defined");
        }

        private async Task<bool> BeUniqueFinanceYear(CreateFinanceYearCommand command,int year, CancellationToken cancellationToken)
        {
            var result = await _context.FinanceYears.AnyAsync(f => f.CustomerId == command.CustomerId && f.Year == year && f.IsActive);
            return !result;
        }

        private async Task<bool> BeExistCustomer(Guid customerId, CancellationToken cancellationToken)
        {
            var result = await _context.Customers.AnyAsync(c => c.Id == customerId);
            return result;
        }
    }
}

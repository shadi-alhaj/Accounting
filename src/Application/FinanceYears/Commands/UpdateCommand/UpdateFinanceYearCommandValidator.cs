using Accounting.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Accounting.Application.FinanceYears.Commands.UpdateCommand
{
    public class UpdateFinanceYearCommandValidator : AbstractValidator<UpdateFinanceYearCommand>
    {
        private readonly IApplicationDbContext context;
        public UpdateFinanceYearCommandValidator(IApplicationDbContext context)
        {
            this.context = context;
            int year = 1980;
            int currentYear = DateTime.Now.Year + 1;
            RuleFor(v => v.CustomerId)
                 .NotEmpty().WithMessage("Customer Id can't be null")
                 .MustAsync(BeExistCustomer).WithMessage("Invalid Customer");

            RuleFor(v => v.Year)
                .NotEmpty().WithMessage("Finance Year can not be empty")
                .LessThan(currentYear).WithMessage($"The Finance year should not be in the future")
                .GreaterThan(year).WithMessage($"The Finance year should be greater than {year}")
                .MustAsync(BeUniqueFinanceYear).WithMessage("The finance year already defined");
        }

        private async Task<bool> BeUniqueFinanceYear(UpdateFinanceYearCommand command, int year, CancellationToken cancellationToken)
        {
            var result = await context.FinanceYears.AnyAsync(f => f.CustomerId == command.CustomerId && f.Year == year && f.IsActive);
            return !result;
        }

        private async Task<bool> BeExistCustomer(Guid customerId, CancellationToken cancellationToken)
        {
            var result = await context.Customers.AnyAsync(c => c.Id == customerId);
            return result;
        }
    }
}

using Accounting.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Accounting.Application.TotalAccounts.Commands.DeleteCommand
{
    class DeleteTotalAccountCommandValidator: AbstractValidator<DeleteTotalAccountCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteTotalAccountCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.Id)
                .MustAsync(BeLeafAccount).WithMessage("Can't delete Total account. Detail account(s) related to this total account");
        }

        private async Task<bool> BeLeafAccount(Guid totalAccountId, CancellationToken cancellationToken)
        {
            var result = await _context.DetailAccounts.AnyAsync(d => d.TotalAccountId == totalAccountId && d.IsActive);
            return !result;
        }
    }
}

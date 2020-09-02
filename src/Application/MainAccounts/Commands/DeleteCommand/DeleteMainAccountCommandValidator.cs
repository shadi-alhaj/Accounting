using Accounting.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Accounting.Application.MainAccounts.Commands.DeleteCommand
{
    public class DeleteMainAccountCommandValidator: AbstractValidator<DeleteMainAccountCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteMainAccountCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.Id)
                .MustAsync(BeLeafAccount).WithMessage("Can't delete Main account. Total account(s) related to this main account");
        }

        private async Task<bool> BeLeafAccount(Guid mainAccountId, CancellationToken cancellationToken)
        {
            var result = await _context.TotalAccounts.AnyAsync(t => t.MainAccountId == mainAccountId);
            return !result;
        }
    }
}

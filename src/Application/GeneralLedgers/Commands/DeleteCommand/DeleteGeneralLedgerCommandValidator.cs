using Accounting.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Accounting.Application.GeneralLedgers.Commands.DeleteCommand
{
    public class DeleteGeneralLedgerCommandValidator: AbstractValidator<DeleteGeneralLedgerCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteGeneralLedgerCommandValidator(IApplicationDbContext context)
        {
            _context = context;
            RuleFor(v => v.Id)
                .MustAsync(BeLeafAccount).WithMessage("Can't delete General leadger account. Main account(s) related to this general leadger account");
        }

        private async Task<bool> BeLeafAccount(Guid glId, CancellationToken cancellationToken)
        {
            var result = await _context.MainAccounts.AnyAsync(m => m.GeneralLeadgerId != glId);
            return result;
        }
    }
}

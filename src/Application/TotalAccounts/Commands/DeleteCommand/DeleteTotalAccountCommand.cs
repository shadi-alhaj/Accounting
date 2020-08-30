using Accounting.Application.Common.Exceptions;
using Accounting.Application.Common.Interfaces;
using Accounting.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace Accounting.Application.TotalAccounts.Commands.DeleteCommand
{
    public class DeleteTotalAccountCommand : IRequest
    {
        public Guid Id { get; set; }

        public class DeleteTotalAccountCommandHandler : IRequestHandler<DeleteTotalAccountCommand>
        {
            private readonly IApplicationDbContext _context;

            public DeleteTotalAccountCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(DeleteTotalAccountCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.TotalAccounts
                    .Where(l => l.Id == request.Id)
                    .SingleOrDefaultAsync(cancellationToken);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(TotalAccount), request.Id);
                }

                entity.IsActive = false;

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}

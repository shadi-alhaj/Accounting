using Accounting.Application.Common.Exceptions;
using Accounting.Application.Common.Interfaces;
using Accounting.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace Accounting.Application.DailyTransactions.Commands.DeleteCommand
{
    public class DeleteDailyTransactionCommand : IRequest
    {
        public Guid Id { get; set; }

        public class DeleteDailyTransactionCommandHandler : IRequestHandler<DeleteDailyTransactionCommand>
        {
            private readonly IApplicationDbContext _context;

            public DeleteDailyTransactionCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(DeleteDailyTransactionCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.DailyTransactions
                    .Where(l => l.Id == request.Id)
                    .SingleOrDefaultAsync(cancellationToken);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(DailyTransaction), request.Id);
                }

                entity.IsActive = false;

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}

using Accounting.Application.Common.Exceptions;
using Accounting.Application.Common.Interfaces;
using Accounting.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace Accounting.Application.DetailAccounts.Commands.DeleteCommand
{
    public class DeleteDetailAccountCommand : IRequest
    {
        public Guid Id { get; set; }

        public class DeleteDetailAccountCommandHandler : IRequestHandler<DeleteDetailAccountCommand>
        {
            private readonly IApplicationDbContext _context;

            public DeleteDetailAccountCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(DeleteDetailAccountCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.DetailAccounts
                    .Where(l => l.Id == request.Id)
                    .SingleOrDefaultAsync(cancellationToken);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(DetailAccount), request.Id);
                }

                entity.IsActive = false;

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}

using Accounting.Application.Common.Exceptions;
using Accounting.Application.Common.Interfaces;
using Accounting.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace Accounting.Application.MainAccounts.Commands.DeleteCommand
{
    public class DeleteMainAccountCommand : IRequest
    {
        public Guid Id { get; set; }

        public class DeleteMainAccountCommandHandler : IRequestHandler<DeleteMainAccountCommand>
        {
            private readonly IApplicationDbContext _context;

            public DeleteMainAccountCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(DeleteMainAccountCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.MainAccounts
                    .Where(l => l.Id == request.Id)
                    .SingleOrDefaultAsync(cancellationToken);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(MainAccount), request.Id);
                }

                entity.IsActive = false;

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}

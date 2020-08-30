using Accounting.Application.Common.Exceptions;
using Accounting.Application.Common.Interfaces;
using Accounting.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace Accounting.Application.Bonds.Commands.DeleteCommand
{
    public class DeleteBondCommand : IRequest
    {
        public Guid Id { get; set; }
        public class DeleteBondCommandHandler : IRequestHandler<DeleteBondCommand>
        {
            private readonly IApplicationDbContext _context;

            public DeleteBondCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(DeleteBondCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Bonds
                    .Where(l => l.Id == request.Id)
                    .SingleOrDefaultAsync(cancellationToken);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Bond), request.Id);
                }

                entity.IsActive = false;

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}

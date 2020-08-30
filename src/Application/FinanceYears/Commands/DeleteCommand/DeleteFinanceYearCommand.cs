using Accounting.Application.Common.Exceptions;
using Accounting.Application.Common.Interfaces;
using Accounting.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace Accounting.Application.FinanceYears.Commands.DeleteCommand
{
    public class DeleteFinanceYearCommand : IRequest
    {
        public Guid Id { get; set; }

        public class DeleteFinanceYearCommandHandler : IRequestHandler<DeleteFinanceYearCommand>
        {
            private readonly IApplicationDbContext _context;

            public DeleteFinanceYearCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(DeleteFinanceYearCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.FinanceYears
                    .Where(l => l.Id == request.Id)
                    .SingleOrDefaultAsync(cancellationToken);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(FinanceYear), request.Id);
                }

                entity.IsActive = false;

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}

using Accounting.Application.Common.Exceptions;
using Accounting.Application.Common.Interfaces;
using Accounting.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Accounting.Application.FinanceYears.Commands.UpdateCommand
{
    public class UpdateFinanceYearCommand : IRequest
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public int Year { get; set; }


        public class UpdateFinanceYearCommandHandler : IRequestHandler<UpdateFinanceYearCommand>
        {
            private readonly IApplicationDbContext _context;

            public UpdateFinanceYearCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(UpdateFinanceYearCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.FinanceYears.FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(FinanceYear), request.Id);
                }

                entity.Year = request.Year;

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}

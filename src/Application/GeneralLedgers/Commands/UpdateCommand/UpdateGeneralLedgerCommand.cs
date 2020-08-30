using Accounting.Application.Common.Exceptions;
using Accounting.Application.Common.Interfaces;
using Accounting.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Accounting.Application.GeneralLedgers.Commands.UpdateCommand
{
    public class UpdateGeneralLedgerCommand : IRequest
    {
        public Guid Id { get; set; }
        public string GLNameAr { get; set; }
        public string GlNameEn { get; set; }

        public class UpdateGeneralLedgerCommandHandler : IRequestHandler<UpdateGeneralLedgerCommand>
        {
            private readonly IApplicationDbContext _context;

            public UpdateGeneralLedgerCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(UpdateGeneralLedgerCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.GeneralLedgers.FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(GeneralLedger), request.Id);
                }

                entity.GLNameAr = request.GLNameAr;
                entity.GlNameEn = request.GlNameEn;

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}

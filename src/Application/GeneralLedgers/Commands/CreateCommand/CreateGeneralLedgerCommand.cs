using Accounting.Application.Common.Interfaces;
using Accounting.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Accounting.Application.GeneralLedgers.Commands.CreateCommand
{
    public class CreateGeneralLedgerCommand : IRequest<Guid>
    {
        public int GlIdByCustomer { get; set; }
        public string GLNameAr { get; set; }
        public string GlNameEn { get; set; }
        public Guid CustomerId { get; set; }

        public class CreateGeneralLedgerCommandHandler : IRequestHandler<CreateGeneralLedgerCommand, Guid>
        {
            private readonly IApplicationDbContext _context;
            public CreateGeneralLedgerCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Guid> Handle(CreateGeneralLedgerCommand request, CancellationToken cancellationToken)
            {
                var entity = new GeneralLedger
                {
                    GlIdByCustomer = request.GlIdByCustomer,
                    GLNameAr = request.GLNameAr,
                    GlNameEn = request.GlNameEn,
                    CustomerId = request.CustomerId
                };

                _context.GeneralLedgers.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return entity.Id;
            }
        }
    }
}
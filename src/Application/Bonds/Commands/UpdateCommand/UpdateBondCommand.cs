using Accounting.Application.Common.Exceptions;
using Accounting.Application.Common.Interfaces;
using Accounting.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Accounting.Application.Bonds.Commands.UpdateCommand
{
    public class UpdateBondCommand : IRequest
    {
        public Guid Id { get; set; }
        public int IntialSNo { get; set; }
        public string BondNameAr { get; set; }
        public string BondNameEn { get; set; }
       

        public class UpdateBondCommandHandler : IRequestHandler<UpdateBondCommand>
        {
            private readonly IApplicationDbContext _context;

            public UpdateBondCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(UpdateBondCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Bonds.FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Bond), request.Id);
                }

                entity.IntialSNo = request.IntialSNo;
                entity.BondNameAr = request.BondNameAr;
                entity.BondNameEn = request.BondNameEn;

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}

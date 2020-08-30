using Accounting.Application.Common.Interfaces;
using Accounting.Domain.Entities;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Accounting.Application.Bonds.Commands.CreateCommand
{
    public class CreateBondCommand : IRequest<Guid>
    {
        public int BondUserId { get; set; }
        public int IntialSNo { get; set; }
        public string BondNameAr { get; set; }
        public string BondNameEn { get; set; }
        public Guid CustomerId { get; set; }

        public class CreateBondCommandHandler : IRequestHandler<CreateBondCommand, Guid>
        {
            private readonly IApplicationDbContext _context;
            public CreateBondCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Guid> Handle(CreateBondCommand request, CancellationToken cancellationToken)
            {               
                var entity = new Bond
                {
                    BondUserId =request.BondUserId,
                    IntialSNo = request.IntialSNo,
                    BondNameAr = request.BondNameAr,
                    BondNameEn = request.BondNameEn,
                    CustomerId = request.CustomerId
                };

                _context.Bonds.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return entity.Id;
            }
        }
    }
}
using Accounting.Application.Common.Exceptions;
using Accounting.Application.Common.Interfaces;
using Accounting.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Accounting.Application.DetailAccounts.Commands.UpdateCommand
{
    public class UpdateDetailAccountCommand : IRequest
    {
        public Guid Id { get; set; }     
        public string DetailAccountNameAr { get; set; }
        public string DetailAccountNameEn { get; set; }

        public class UpdateDetailAccountCommandHandler : IRequestHandler<UpdateDetailAccountCommand>
        {
            private readonly IApplicationDbContext _context;

            public UpdateDetailAccountCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(UpdateDetailAccountCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.DetailAccounts.FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(DetailAccount), request.Id);
                }

                entity.DetailAccountNameAr = request.DetailAccountNameAr;
                entity.DetailAccountNameEn = request.DetailAccountNameEn;

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}

using Accounting.Application.Common.Exceptions;
using Accounting.Application.Common.Interfaces;
using Accounting.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Accounting.Application.MainAccounts.Commands.UpdateCommand
{
    public class UpdateMainAccountCommand : IRequest
    {
        public Guid Id { get; set; }
        public string MainAccountNameAr { get; set; }
        public string MainAccountNameEn { get; set; }

        public class UpdateMainAccountCommandHandler : IRequestHandler<UpdateMainAccountCommand>
        {
            private readonly IApplicationDbContext _context;

            public UpdateMainAccountCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(UpdateMainAccountCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.MainAccounts.FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(MainAccount), request.Id);
                }

                entity.MainAccountNameAr = request.MainAccountNameAr;
                entity.MainAccountNameEn = request.MainAccountNameEn;

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}

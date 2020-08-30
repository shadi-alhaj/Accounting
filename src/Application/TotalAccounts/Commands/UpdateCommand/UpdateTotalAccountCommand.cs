using Accounting.Application.Common.Exceptions;
using Accounting.Application.Common.Interfaces;
using Accounting.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Accounting.Application.TotalAccounts.Commands.UpdateCommand
{
    public class UpdateTotalAccountCommand : IRequest
    {
        public Guid Id { get; set; }       
        public string TotalAccountNameAr { get; set; }
        public string TotalAccountNameEn { get; set; }
        public bool IsClose { get; set; }

        public class UpdateTotalAccountCommandHandler : IRequestHandler<UpdateTotalAccountCommand>
        {
            private readonly IApplicationDbContext _context;

            public UpdateTotalAccountCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(UpdateTotalAccountCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.TotalAccounts.FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(TotalAccount), request.Id);
                }

                entity.TotalAccountNameAr = request.TotalAccountNameAr;
                entity.TotalAccountNameEn = request.TotalAccountNameEn;
                entity.IsClose = request.IsClose;


                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}

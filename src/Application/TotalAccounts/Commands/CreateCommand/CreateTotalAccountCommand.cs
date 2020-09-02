using Accounting.Application.Common.Exceptions;
using Accounting.Application.Common.Interfaces;
using Accounting.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Accounting.Application.TotalAccounts.Commands.CreateCommand
{
    public class CreateTotalAccountCommand : IRequest<Guid>
    {       
        public int TotalAccountIdByCustomer { get; set; }
        public string TotalAccountNameAr { get; set; }
        public string TotalAccountNameEn { get; set; }
        public Guid CustomerId { get; set; }        
        public Guid MainAccountId { get; set; }
        public bool IsClose { get; set; }     

        public class CreateTotalAccountCommandHandler : IRequestHandler<CreateTotalAccountCommand, Guid>
        {
            private readonly IApplicationDbContext _context;
            public CreateTotalAccountCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Guid> Handle(CreateTotalAccountCommand request, CancellationToken cancellationToken)
            {
                var glId = await _context.MainAccounts.Where(m => m.CustomerId == request.CustomerId && m.Id == request.MainAccountId && m.IsActive).Select(m => m.GeneralLeadgerId).SingleOrDefaultAsync();

                if(glId == null)
                {
                    throw new NotFoundException(nameof(TotalAccount), request.MainAccountId);
                }

                var entity = new TotalAccount
                {
                    TotalAccountIdByCustomer = request.TotalAccountIdByCustomer,
                    TotalAccountNameAr = request.TotalAccountNameAr,
                    TotalAccountNameEn = request.TotalAccountNameEn,
                    CustomerId = request.CustomerId,
                    IsClose = request.IsClose,
                    MainAccountId = request.MainAccountId,
                    GeneralLeadgerId = glId
                };


                _context.TotalAccounts.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return entity.Id;
            }
        }
    }
}
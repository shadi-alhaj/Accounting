using Accounting.Application.Common.Interfaces;
using Accounting.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Accounting.Application.MainAccounts.Commands.CreateCommand
{
    public class CreateMainAccountCommand : IRequest<Guid>
    {
        public int MainAccountIdByCustomer { get; set; }
        public string MainAccountNameAr { get; set; }
        public string MainAccountNameEn { get; set; }
        public Guid CustomerId { get; set; }
        public Guid GeneralLeadgerId { get; set; }  

        public class CreateMainAccountCommandHandler : IRequestHandler<CreateMainAccountCommand, Guid>
        {
            private readonly IApplicationDbContext _context;
            public CreateMainAccountCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Guid> Handle(CreateMainAccountCommand request, CancellationToken cancellationToken)
            {
                var entity = new MainAccount
                {
                    MainAccountIdByCustomer = request.MainAccountIdByCustomer,
                    MainAccountNameAr = request.MainAccountNameAr,
                    MainAccountNameEn = request.MainAccountNameEn,
                    CustomerId = request.CustomerId,
                    GeneralLeadgerId = request.GeneralLeadgerId
                };

                _context.MainAccounts.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return entity.Id;
            }
        }
    }
}
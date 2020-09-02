using Accounting.Application.Common.Interfaces;
using Accounting.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Accounting.Application.DetailAccounts.Commands.CreateCommand
{
    public class CreateDetailAccountCommand : IRequest<Guid>
    {
        public int DetailAccountIdByCustomer { get; set; }
        public string DetailAccountNameAr { get; set; }
        public string DetailAccountNameEn { get; set; }
        public Guid CustomerId { get; set; }
        public Guid GeneralLeadgerId { get; set; }
        public Guid MainAccountId { get; set; }
        public Guid TotalAccountId { get; set; }       

        public class CreateDetailAccountCommandHandler : IRequestHandler<CreateDetailAccountCommand, Guid>
        {
            private readonly IApplicationDbContext _context;
            public CreateDetailAccountCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Guid> Handle(CreateDetailAccountCommand request, CancellationToken cancellationToken)
            {
                var entity = new DetailAccount
                {
                    DetailAccountIdByCustomer = request.DetailAccountIdByCustomer,
                    DetailAccountNameAr = request.DetailAccountNameAr,
                    DetailAccountNameEn = request.DetailAccountNameEn,
                    CustomerId = request.CustomerId,
                    GeneralLeadgerId = request.GeneralLeadgerId,
                    MainAccountId = request.MainAccountId,
                    TotalAccountId = request.TotalAccountId
                };

                _context.DetailAccounts.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return entity.Id;
            }
        }
    }
}
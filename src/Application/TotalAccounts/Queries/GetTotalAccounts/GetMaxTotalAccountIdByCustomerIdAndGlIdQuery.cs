using Accounting.Application.Common.Exceptions;
using Accounting.Application.Common.Interfaces;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Accounting.Application.TotalAccounts.Queries.GetTotalAccounts
{
    public class GetMaxTotalAccountIdByCustomerIdAndGlIdQuery: IRequest<int>
    {
        public Guid CustomerId { get; set; }
        public int MainAccountIdByCustomer { get; set; }
        public class GetMaxTotalAccountIdByCustomerIdAndGlIdQueryHandler : IRequestHandler<GetMaxTotalAccountIdByCustomerIdAndGlIdQuery, int>
        {
            private readonly IApplicationDbContext _context;

            public GetMaxTotalAccountIdByCustomerIdAndGlIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public Task<int> Handle(GetMaxTotalAccountIdByCustomerIdAndGlIdQuery request, CancellationToken cancellationToken)
            {
                var mainAccountId = _context.MainAccounts
                  .Where(m => m.CustomerId == request.CustomerId && m.MainAccountIdByCustomer == request.MainAccountIdByCustomer && m.IsActive)
                  .Select(m => m.Id)
                  .SingleOrDefault();

                if (mainAccountId == null)
                {
                    throw new NotFoundException(nameof(GeneralLedgers), request.MainAccountIdByCustomer);
                }

                var maxTotalAccountId = _context.TotalAccounts
                    .Where(t => t.CustomerId == request.CustomerId && t.MainAccountId == mainAccountId && t.IsActive)
                    .Max(e => (int?)e.TotalAccountIdByCustomer) ?? (request.MainAccountIdByCustomer * 10);

                return Task.FromResult(maxTotalAccountId + 1);
            }
        }
    }
}

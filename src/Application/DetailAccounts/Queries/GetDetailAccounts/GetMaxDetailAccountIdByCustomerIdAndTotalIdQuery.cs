using Accounting.Application.Common.Exceptions;
using Accounting.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Accounting.Application.DetailAccounts.Queries.GetDetailAccounts
{
    public class GetMaxDetailAccountIdByCustomerIdAndTotalIdQuery : IRequest<int>
    {
        public Guid CustomerId { get; set; }
        public int TotalAccountIdByCustomer { get; set; }
        public class GetMaxDetailAccountIdByCustomerIdAndTotalIdQueryHandler : IRequestHandler<GetMaxDetailAccountIdByCustomerIdAndTotalIdQuery, int>
        {
            private readonly IApplicationDbContext _context;

            public GetMaxDetailAccountIdByCustomerIdAndTotalIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public Task<int> Handle(GetMaxDetailAccountIdByCustomerIdAndTotalIdQuery request, CancellationToken cancellationToken)
            {
                var totalAccountId = _context.TotalAccounts
                    .Where(t => t.CustomerId == request.CustomerId && t.TotalAccountIdByCustomer == request.TotalAccountIdByCustomer && t.IsActive)
                    .Select(t => t.Id)
                    .SingleOrDefault();

                if (totalAccountId == null)
                {
                    throw new NotFoundException(nameof(TotalAccounts), request.TotalAccountIdByCustomer);
                }

                var maxDetailAccountId = _context.DetailAccounts
                    .Where(d => d.CustomerId == request.CustomerId && d.TotalAccountId == totalAccountId && d.IsActive)
                    .Max(e => (int?)e.DetailAccountIdByCustomer) ?? (request.TotalAccountIdByCustomer * 1000);

                return Task.FromResult(maxDetailAccountId + 1);
            }
        }
    }
}

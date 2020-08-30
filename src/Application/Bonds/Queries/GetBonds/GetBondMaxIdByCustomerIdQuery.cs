using Accounting.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Accounting.Application.Bonds.Queries.GetBonds
{
    public class GetBondMaxIdByCustomerIdQuery: IRequest<int>
    {
        public Guid CustomerId { get; set; }
        public class GetBondMaxIdByCustomerIdQueryHandler : IRequestHandler<GetBondMaxIdByCustomerIdQuery, int>
        {
            private readonly IApplicationDbContext _context;

            public GetBondMaxIdByCustomerIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public Task<int> Handle(GetBondMaxIdByCustomerIdQuery request, CancellationToken cancellationToken)
            {
                var maxBondUserId = _context.Bonds.Where(b => b.CustomerId == request.CustomerId && b.IsActive).Max(e => (int?)e.BondUserId) ?? 0;
                return Task.FromResult(maxBondUserId + 1);
            }
        }
    }
}

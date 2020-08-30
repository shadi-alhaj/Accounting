using Accounting.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Accounting.Application.GeneralLedgers.Queries.GetGeneralLedgers
{
    public class GetMaxGlIdByCustomerIdQuery: IRequest<int>
    {
        public Guid CustomerId { get; set; }
        public class GetMaxGlIdByCustomerIdQueryHandler : IRequestHandler<GetMaxGlIdByCustomerIdQuery, int>
        {
            private readonly IApplicationDbContext _context;

            public GetMaxGlIdByCustomerIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public Task<int> Handle(GetMaxGlIdByCustomerIdQuery request, CancellationToken cancellationToken)
            {
                var maxGlId = _context.GeneralLedgers.Where(g => g.CustomerId == request.CustomerId && g.IsActive).Max(e => (int?)e.GlIdByCustomer) ?? 0;
                return Task.FromResult(maxGlId + 1);
            }
        }
    }
}

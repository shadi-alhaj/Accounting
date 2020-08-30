using Accounting.Application.Common.Exceptions;
using Accounting.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Accounting.Application.MainAccounts.Queries.GetMainAccounts
{
    public class GetMaxMainAccountIdByCustomerIdAndGlIdQuery : IRequest<int>
    {
        public Guid CustomerId { get; set; }
        public int GlIdByCustomer { get; set; }

        public class GetMaxMainAccountIdByCustomerIdAndGlIdQueryHandler : IRequestHandler<GetMaxMainAccountIdByCustomerIdAndGlIdQuery, int>
        {
            private readonly IApplicationDbContext _context;

            public GetMaxMainAccountIdByCustomerIdAndGlIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public Task<int> Handle(GetMaxMainAccountIdByCustomerIdAndGlIdQuery request, CancellationToken cancellationToken)
            {
                var glId = _context.GeneralLedgers
                    .Where(g => g.CustomerId == request.CustomerId && g.GlIdByCustomer == request.GlIdByCustomer && g.IsActive)
                    .Select(g => g.Id)
                    .SingleOrDefault();

                if(glId == null)
                {
                    throw new NotFoundException(nameof(GeneralLedgers), request.GlIdByCustomer);
                }

                var maxMainAccountId = _context.MainAccounts
                    .Where(m => m.CustomerId == request.CustomerId && m.GeneralLeadgerId == glId && m.IsActive)
                    .Max(e => (int?)e.MainAccountIdByCustomer) ?? (request.GlIdByCustomer  * 10);

                return Task.FromResult(maxMainAccountId + 1);
            }
        }
    }
}

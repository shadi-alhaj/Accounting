using Accounting.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Accounting.Application.TotalAccounts.Queries.GetTotalAccounts
{
    public class GetTotalAccountByTotalAccountIdByCustomerAndCustomerIdQuery: IRequest<TotalAccountDto>
    {
        public Guid CustomerId { get; set; }
        public int TotalAccountIdByCustomer { get; set; }
        public class GetTotalAccountByTotalAccountIdByCustomerAndCustomerIdQueryHandler : IRequestHandler<GetTotalAccountByTotalAccountIdByCustomerAndCustomerIdQuery, TotalAccountDto>
        {
            private readonly IApplicationDbContext _context;

            public GetTotalAccountByTotalAccountIdByCustomerAndCustomerIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<TotalAccountDto> Handle(GetTotalAccountByTotalAccountIdByCustomerAndCustomerIdQuery request, CancellationToken cancellationToken)
            {
                var result = await _context.TotalAccounts.Where(t => t.CustomerId == t.CustomerId && t.TotalAccountIdByCustomer == request.TotalAccountIdByCustomer && t.IsActive)
                    .Select(t => new TotalAccountDto
                    {
                        Id = t.Id,
                        TotalAccountNameAr = t.TotalAccountNameAr,
                        MainAccountId = t.MainAccountId,
                        GeneralLeadgerId = t.GeneralLeadgerId
                    }).SingleOrDefaultAsync();

                return result;
            }
        }
    }
}

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
    public class GetMainAccountByMainAccountIdByCustomerAndCustomerIdQuery: IRequest<MainAccountDto>
    {
        public Guid CustomerId { get; set; }
        public int MainAccountIdByCustomer { get; set; }
        public class GetMainAccountByMainAccountIdByCustomerAndCustomerIdQueryHandler : IRequestHandler<GetMainAccountByMainAccountIdByCustomerAndCustomerIdQuery, MainAccountDto>
        {
            private readonly IApplicationDbContext _context;

            public GetMainAccountByMainAccountIdByCustomerAndCustomerIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<MainAccountDto> Handle(GetMainAccountByMainAccountIdByCustomerAndCustomerIdQuery request, CancellationToken cancellationToken)
            {
                var result = await _context.MainAccounts
                    .Where(m => m.CustomerId == request.CustomerId && m.MainAccountIdByCustomer == request.MainAccountIdByCustomer && m.IsActive)
                    .Include(m => m.GeneralLedger)
                    .Select(m => new MainAccountDto
                    {
                        Id = m.Id,
                        MainAccountIdByCustomer = m.MainAccountIdByCustomer,
                        MainAccountNameAr = m.MainAccountNameAr,
                        GeneralLeadgerId = m.GeneralLeadgerId
                    }).SingleOrDefaultAsync();

                return result;
            }
        }
    }
}

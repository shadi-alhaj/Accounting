using AutoMapper;
using AutoMapper.QueryableExtensions;
using Accounting.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace Accounting.Application.DetailAccounts.Queries.GetDetailAccounts
{
    public class GetDetailAccountsQuery : IRequest<DetailAccountVm>
    {
        public Guid CustomerId { get; set; }
        public class GetDetailAccountsQueryHandler : IRequestHandler<GetDetailAccountsQuery, DetailAccountVm>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public GetDetailAccountsQueryHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<DetailAccountVm> Handle(GetDetailAccountsQuery request, CancellationToken cancellationToken)
            {
                var vm = new DetailAccountVm();

                vm.Lists = await _context.DetailAccounts
                            .Where(d => d.CustomerId == request.CustomerId && d.IsActive)
                            .Include(d => d.TotalAccount)
                            .Select(d => new DetailAccountDto
                            {
                                Id = d.Id,
                                DetailAccountIdByCustomer = d.DetailAccountIdByCustomer,
                                DetailAccountNameAr = d.DetailAccountNameAr,
                                DetailAccountNameEn = d.DetailAccountNameEn,
                                TotalAccountNameAr = d.TotalAccount.TotalAccountNameAr,
                                CustomerId = d.CustomerId,
                                GeneralLeadgerId = d.GeneralLeadgerId,
                                MainAccountId = d.MainAccountId,
                                TotalAccountId = d.TotalAccountId
                            })
                            .ToListAsync(cancellationToken);

                return vm;
            }
        }
    }
}

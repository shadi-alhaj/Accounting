using AutoMapper;
using AutoMapper.QueryableExtensions;
using Accounting.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System;
using Accounting.Application.MainAccounts.Queries.GetMainAccounts;

namespace Accounting.Application.TotalAccounts.Queries.GetTotalAccounts
{
    public class GetTotalAccountsQuery : IRequest<TotalAccountVm>
    {
        public Guid  CustomerId { get; set; }
        public class GetTotalAccountsQueryHandler : IRequestHandler<GetTotalAccountsQuery, TotalAccountVm>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public GetTotalAccountsQueryHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<TotalAccountVm> Handle(GetTotalAccountsQuery request, CancellationToken cancellationToken)
            {
                var vm = new TotalAccountVm();

                vm.Lists = await _context.TotalAccounts
                                .Where(t => t.CustomerId == request.CustomerId && t.IsActive)
                                .Include(t => t.MainAccount)
                                .Select(t => new TotalAccountDto
                                {
                                    Id  = t.Id,
                                    TotalAccountNameAr = t.TotalAccountNameAr,
                                    TotalAccountNameEn = t.TotalAccountNameEn,
                                    IsClose = t.IsClose,
                                    TotalAccountIdByCustomer = t.TotalAccountIdByCustomer,
                                    MainAccountId = t.MainAccountId,
                                    MainAccountIdByCustomer = t.MainAccount.MainAccountIdByCustomer,
                                    MainAccountNameAr = t.MainAccount.MainAccountNameAr,
                                    GeneralLeadgerId = t.MainAccount.GeneralLeadgerId
                                    
                                })
                                .OrderBy(t => t.TotalAccountIdByCustomer).ThenBy(t => t.MainAccountId)
                                .ToListAsync(cancellationToken);

                //vm.Lists = await _context.TotalAccounts.Where(t => t.CustomerId == request.CustomerId && t.IsActive).Include(t => t.MainAccount)
                //    .ProjectTo<TotalAccountDto>(_mapper.ConfigurationProvider)
                //    .OrderBy(t => t.TotalAccountIdByCustomer).ThenBy(t => t.MainAccountId)
                //    .ToListAsync(cancellationToken);

                return vm;
            }
        }
    }
}

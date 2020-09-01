using AutoMapper;
using AutoMapper.QueryableExtensions;
using Accounting.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace Accounting.Application.MainAccounts.Queries.GetMainAccounts
{
    public class GetMainAccountsQuery : IRequest<MainAccountVm>
    {
        public Guid CustomerId { get; set; }
        public class GetMainAccountsQueryHandler : IRequestHandler<GetMainAccountsQuery, MainAccountVm>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public GetMainAccountsQueryHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<MainAccountVm> Handle(GetMainAccountsQuery request, CancellationToken cancellationToken)
            {
                var vm = new MainAccountVm();

                vm.Lists = await _context.MainAccounts.Where(m => m.CustomerId == request.CustomerId && m.IsActive).Include(m => m.GeneralLedger)
                .Select(m => new MainAccountDto
                {
                    Id = m.Id,
                    MainAccountIdByCustomer = m.MainAccountIdByCustomer,
                    MainAccountNameAr = m.MainAccountNameAr,
                    MainAccountNameEn = m.MainAccountNameEn,
                    CustomerId = m.CustomerId,
                    GeneralLeadgerId = m.GeneralLeadgerId,
                    GlIdByCustomer = m.GeneralLedger.GlIdByCustomer,
                    GLNameAr = m.GeneralLedger.GLNameAr
                })
                .OrderBy(m => m.GeneralLeadgerId).ThenBy(m => m.MainAccountIdByCustomer)
                .ToListAsync(cancellationToken);


                //vm.Lists = await _context.MainAccounts.Where(m => m.CustomerId == request.CustomerId && m.IsActive)
                //    .Select(m => new MainAccountDto
                //    {
                //        Id = m.Id,
                //        MainAccountIdByCustomer = m.MainAccountIdByCustomer,
                //        MainAccountNameAr = m.MainAccountNameAr,
                //        MainAccountNameEn = m.MainAccountNameEn,
                //        CustomerId = m.CustomerId,
                //        GeneralLeadgerId = m.GeneralLeadgerId,
                //        GlIdByCustomer = _context.GeneralLedgers.Where(g => g.Id == m.GeneralLeadgerId && g.IsActive).Select(g => g.GlIdByCustomer).FirstOrDefault(),
                //        GLNameAr = _context.GeneralLedgers.Where(g => g.Id == m.GeneralLeadgerId && g.IsActive).Select(g => g.GLNameAr).FirstOrDefault()
                //    })
                //    .OrderBy(m => m.GeneralLeadgerId).ThenBy(m => m.MainAccountIdByCustomer)
                //    .ToListAsync(cancellationToken);

                return vm;
            }
        }
    }
}

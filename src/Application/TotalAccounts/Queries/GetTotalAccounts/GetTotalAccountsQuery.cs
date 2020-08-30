using AutoMapper;
using AutoMapper.QueryableExtensions;
using Accounting.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace Accounting.Application.TotalAccounts.Queries.GetTotalAccounts
{
    public class GetTotalAccountsQuery : IRequest<TotalAccountVm>
    {
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
                    .ProjectTo<TotalAccountDto>(_mapper.ConfigurationProvider)
                    //.OrderBy(t => t.Name)
                    .ToListAsync(cancellationToken);

                return vm;
            }
        }
    }
}

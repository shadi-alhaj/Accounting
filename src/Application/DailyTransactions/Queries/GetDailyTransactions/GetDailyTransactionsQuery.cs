using AutoMapper;
using AutoMapper.QueryableExtensions;
using Accounting.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace Accounting.Application.DailyTransactions.Queries.GetDailyTransactions
{
    public class GetDailyTransactionsQuery : IRequest<DailyTransactionVm>
    {
        public class GetDailyTransactionsQueryHandler : IRequestHandler<GetDailyTransactionsQuery, DailyTransactionVm>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public GetDailyTransactionsQueryHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<DailyTransactionVm> Handle(GetDailyTransactionsQuery request, CancellationToken cancellationToken)
            {
                var vm = new DailyTransactionVm();

                vm.Lists = await _context.DailyTransactions
                    .ProjectTo<DailyTransactionDto>(_mapper.ConfigurationProvider)
                    //.OrderBy(t => t.Name)
                    .ToListAsync(cancellationToken);

                return vm;
            }
        }
    }
}

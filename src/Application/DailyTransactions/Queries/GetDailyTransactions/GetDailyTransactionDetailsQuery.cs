using AutoMapper;
using AutoMapper.QueryableExtensions;
using Accounting.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace Accounting.Application.DailyTransactions.Queries.GetDailyTransactions
{
    public class GetDailyTransactionDetailsQuery : IRequest<DailyTransactionDetailsVm>
    {
        public Guid Id { get; set; }

        public class GetDailyTransactionDetailsQueryHandler : IRequestHandler<GetDailyTransactionDetailsQuery, DailyTransactionDetailsVm>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public GetDailyTransactionDetailsQueryHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<DailyTransactionDetailsVm> Handle(GetDailyTransactionDetailsQuery request, CancellationToken cancellationToken)
            {
                var vm = await _context.DailyTransactions
                    .ProjectTo<DailyTransactionDetailsVm>(_mapper.ConfigurationProvider)
                    .Where(e => e.Id == request.Id)
                    .SingleOrDefaultAsync(cancellationToken);

                return vm;
            }
        }
    }
}
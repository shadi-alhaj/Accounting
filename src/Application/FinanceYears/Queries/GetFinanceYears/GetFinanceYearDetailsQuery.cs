using AutoMapper;
using AutoMapper.QueryableExtensions;
using Accounting.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace Accounting.Application.FinanceYears.Queries.GetFinanceYears
{
    public class GetFinanceYearDetailsQuery : IRequest<FinanceYearDetailsVm>
    {
        public long Id { get; set; }

        public class GetFinanceYearDetailsQueryHandler : IRequestHandler<GetFinanceYearDetailsQuery, FinanceYearDetailsVm>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public GetFinanceYearDetailsQueryHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<FinanceYearDetailsVm> Handle(GetFinanceYearDetailsQuery request, CancellationToken cancellationToken)
            {
                var vm = await _context.FinanceYears
                    .ProjectTo<FinanceYearDetailsVm>(_mapper.ConfigurationProvider)
                    //.Where(e => e.Id == request.Id)
                    .SingleOrDefaultAsync(cancellationToken);

                return vm;
            }
        }
    }
}
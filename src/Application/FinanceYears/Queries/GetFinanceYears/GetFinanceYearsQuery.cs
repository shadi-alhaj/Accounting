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
    public class GetFinanceYearsQuery : IRequest<FinanceYearVm>
    {
        public class GetFinanceYearsQueryHandler : IRequestHandler<GetFinanceYearsQuery, FinanceYearVm>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public GetFinanceYearsQueryHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<FinanceYearVm> Handle(GetFinanceYearsQuery request, CancellationToken cancellationToken)
            {
                var vm = new FinanceYearVm();

                vm.Lists = await _context.FinanceYears.Where(f => f.IsActive).Select(f => new FinanceYearDto
                {
                    Id = f.Id,
                    Year = f.Year,
                    cusId = f.CustomerId,
                    CustomerId = f.Customer.CustomerId,
                    CustomerNameAr = f.Customer.CustomerNameAr
                })
                    .OrderBy(f => f.CustomerId).ThenBy(f => f.Year)
                    .ToListAsync(cancellationToken); 

                return vm;
            }
        }
    }
}

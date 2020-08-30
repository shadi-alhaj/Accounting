using AutoMapper;
using AutoMapper.QueryableExtensions;
using Accounting.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace Accounting.Application.Customers.Queries.GetCustomers
{
    public class GetCustomersQuery : IRequest<CustomerVm>
    {
        public class GetCustomersQueryHandler : IRequestHandler<GetCustomersQuery, CustomerVm>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public GetCustomersQueryHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<CustomerVm> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
            {
                var vm = new CustomerVm();

                vm.Lists = await _context.Customers.Where(c => c.IsActive)
                    .ProjectTo<CustomerDto>(_mapper.ConfigurationProvider)
                    .OrderBy(c => c.CustomerId)
                    .ToListAsync(cancellationToken);

                return vm;
            }
        }
    }
}

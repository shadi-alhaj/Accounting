using Accounting.Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Accounting.Application.Customers.Queries
{
    public class GetCustomerLovQuery: IRequest<CustomerLovVm>
    {
        public class GetCustomerLovQueryHandler : IRequestHandler<GetCustomerLovQuery, CustomerLovVm>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public GetCustomerLovQueryHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<CustomerLovVm> Handle(GetCustomerLovQuery request, CancellationToken cancellationToken)
            {
                var vm = new CustomerLovVm();
                vm.Lists = await _context.Customers.Where(c => c.IsActive)
                    .ProjectTo<CustomerLovDto>(_mapper.ConfigurationProvider)
                    .OrderBy(c => c.Id)
                    .ToListAsync(cancellationToken);

                return vm;
            }
        }
    }
}

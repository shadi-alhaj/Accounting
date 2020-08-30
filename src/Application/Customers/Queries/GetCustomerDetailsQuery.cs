using AutoMapper;
using AutoMapper.QueryableExtensions;
using Accounting.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace Accounting.Application.Customers.Queries.GetCustomers
{
    public class GetCustomerDetailsQuery : IRequest<CustomerDetailsVm>
    {
        public Guid Id { get; set; }

        public class GetCustomerDetailsQueryHandler : IRequestHandler<GetCustomerDetailsQuery, CustomerDetailsVm>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public GetCustomerDetailsQueryHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<CustomerDetailsVm> Handle(GetCustomerDetailsQuery request, CancellationToken cancellationToken)
            {
                var vm = await _context.Customers
                    .ProjectTo<CustomerDetailsVm>(_mapper.ConfigurationProvider)
                    //.Where(e => e.Id == request.Id)
                    .SingleOrDefaultAsync(cancellationToken);

                return vm;
            }
        }
    }
}
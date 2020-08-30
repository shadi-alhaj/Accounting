using AutoMapper;
using AutoMapper.QueryableExtensions;
using Accounting.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace Accounting.Application.Bonds.Queries.GetBonds
{
    public class GetBondsQuery : IRequest<BondVm>
    {
        public Guid CustomerId { get; set; }
        public class GetBondsQueryHandler : IRequestHandler<GetBondsQuery, BondVm>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public GetBondsQueryHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<BondVm> Handle(GetBondsQuery request, CancellationToken cancellationToken)
            {
                var vm = new BondVm();

                vm.Lists = await _context.Bonds.Where(b => b.IsActive && b.CustomerId == request.CustomerId)
                    .ProjectTo<BondDto>(_mapper.ConfigurationProvider)
                    //.OrderBy(t => t.Name)
                    .ToListAsync(cancellationToken);

                return vm;
            }
        }
    }
}

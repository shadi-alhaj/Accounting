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
    public class GetBondDetailsQuery : IRequest<BondDetailsVm>
    {
        public Guid Id { get; set; }

        public class GetBondDetailsQueryHandler : IRequestHandler<GetBondDetailsQuery, BondDetailsVm>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public GetBondDetailsQueryHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<BondDetailsVm> Handle(GetBondDetailsQuery request, CancellationToken cancellationToken)
            {
                var vm = await _context.Bonds
                    .ProjectTo<BondDetailsVm>(_mapper.ConfigurationProvider)
                    .Where(e => e.Id == request.Id)
                    .SingleOrDefaultAsync(cancellationToken);

                return vm;
            }
        }
    }
}
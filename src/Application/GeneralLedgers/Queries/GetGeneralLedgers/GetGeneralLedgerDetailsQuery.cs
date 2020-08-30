using AutoMapper;
using AutoMapper.QueryableExtensions;
using Accounting.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace Accounting.Application.GeneralLedgers.Queries.GetGeneralLedgers
{
    public class GetGeneralLedgerDetailsQuery : IRequest<GeneralLedgerDetailsVm>
    {
        public Guid Id { get; set; }

        public class GetGeneralLedgerDetailsQueryHandler : IRequestHandler<GetGeneralLedgerDetailsQuery, GeneralLedgerDetailsVm>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public GetGeneralLedgerDetailsQueryHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<GeneralLedgerDetailsVm> Handle(GetGeneralLedgerDetailsQuery request, CancellationToken cancellationToken)
            {
                var vm = await _context.GeneralLedgers
                    .ProjectTo<GeneralLedgerDetailsVm>(_mapper.ConfigurationProvider)
                    .Where(e => e.Id == request.Id)
                    .SingleOrDefaultAsync(cancellationToken);

                return vm;
            }
        }
    }
}
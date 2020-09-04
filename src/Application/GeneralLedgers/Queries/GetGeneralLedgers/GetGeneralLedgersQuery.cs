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
    public class GetGeneralLedgersQuery : IRequest<GeneralLedgerVm>
    {
        public Guid CustomerId { get; set; }
        public class GetGeneralLedgersQueryHandler : IRequestHandler<GetGeneralLedgersQuery, GeneralLedgerVm>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public GetGeneralLedgersQueryHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<GeneralLedgerVm> Handle(GetGeneralLedgersQuery request, CancellationToken cancellationToken)
            {
                var vm = new GeneralLedgerVm();

                vm.Lists = await _context.GeneralLedgers.Where(gl => gl.CustomerId == request.CustomerId &&  gl.IsActive)
                    .ProjectTo<GeneralLedgerDto>(_mapper.ConfigurationProvider)
                    .OrderBy(g => g.GlIdByCustomer)
                    .ToListAsync(cancellationToken);

                var result = await _context.Customers.Where(c => c.Id == request.CustomerId)
                      .Include(c => c.GeneralLedgers).ThenInclude(c => c.MainAccounts).ThenInclude(c => c.TotalAccounts).ThenInclude(c => c.DetailAccounts)
                      .ToListAsync(cancellationToken);

                return vm;
            }
        }
    }
}

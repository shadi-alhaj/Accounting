using AutoMapper;
using AutoMapper.QueryableExtensions;
using Accounting.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace Accounting.Application.TotalAccounts.Queries.GetTotalAccounts
{
    public class GetTotalAccountDetailsQuery : IRequest<TotalAccountDetailsVm>
    {
        public Guid Id { get; set; }

        public class GetTotalAccountDetailsQueryHandler : IRequestHandler<GetTotalAccountDetailsQuery, TotalAccountDetailsVm>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public GetTotalAccountDetailsQueryHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<TotalAccountDetailsVm> Handle(GetTotalAccountDetailsQuery request, CancellationToken cancellationToken)
            {
                var vm = await _context.TotalAccounts
                    .ProjectTo<TotalAccountDetailsVm>(_mapper.ConfigurationProvider)
                    .Where(e => e.Id == request.Id)
                    .SingleOrDefaultAsync(cancellationToken);

                return vm;
            }
        }
    }
}
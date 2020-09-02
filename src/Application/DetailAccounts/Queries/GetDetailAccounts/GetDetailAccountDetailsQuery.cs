using AutoMapper;
using AutoMapper.QueryableExtensions;
using Accounting.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace Accounting.Application.DetailAccounts.Queries.GetDetailAccounts
{
    public class GetDetailAccountDetailsQuery : IRequest<DetailAccountDetailsVm>
    {
        public Guid Id { get; set; }

        public class GetDetailAccountDetailsQueryHandler : IRequestHandler<GetDetailAccountDetailsQuery, DetailAccountDetailsVm>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public GetDetailAccountDetailsQueryHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<DetailAccountDetailsVm> Handle(GetDetailAccountDetailsQuery request, CancellationToken cancellationToken)
            {
                var vm = await _context.DetailAccounts
                    .ProjectTo<DetailAccountDetailsVm>(_mapper.ConfigurationProvider)
                    .Where(e => e.Id == request.Id)
                    .SingleOrDefaultAsync(cancellationToken);

                return vm;
            }
        }
    }
}
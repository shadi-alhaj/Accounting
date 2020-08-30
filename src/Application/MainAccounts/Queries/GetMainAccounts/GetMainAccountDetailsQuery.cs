using AutoMapper;
using AutoMapper.QueryableExtensions;
using Accounting.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace Accounting.Application.MainAccounts.Queries.GetMainAccounts
{
    public class GetMainAccountDetailsQuery : IRequest<MainAccountDetailsVm>
    {
        public Guid Id { get; set; }

        public class GetMainAccountDetailsQueryHandler : IRequestHandler<GetMainAccountDetailsQuery, MainAccountDetailsVm>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public GetMainAccountDetailsQueryHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<MainAccountDetailsVm> Handle(GetMainAccountDetailsQuery request, CancellationToken cancellationToken)
            {
                var vm = await _context.MainAccounts
                    .ProjectTo<MainAccountDetailsVm>(_mapper.ConfigurationProvider)
                    .Where(e => e.Id == request.Id)
                    .SingleOrDefaultAsync(cancellationToken);

                return vm;
            }
        }
    }
}
using Accounting.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Accounting.Application.GeneralLedgers.Queries.GetGeneralLedgers
{
    public class GetGeneralLedgerLovQuery: IRequest<GeneralLedgerLovVm>
    {
        public Guid CustomerId { get; set; }
        public class GetGeneralLedgerLovQueryHandler : IRequestHandler<GetGeneralLedgerLovQuery, GeneralLedgerLovVm>
        {
            private readonly IApplicationDbContext _context;
            public GetGeneralLedgerLovQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<GeneralLedgerLovVm> Handle(GetGeneralLedgerLovQuery request, CancellationToken cancellationToken)
            {
                var vm = new GeneralLedgerLovVm();
                vm.Lists = await _context.GeneralLedgers
                     .Where(g => g.CustomerId == request.CustomerId && g.IsActive)
                     .Select(g => new GeneralLedgerLovDto
                     {
                         Id = g.Id,
                         GLNameAr = g.GLNameAr,
                         GlNameEn = g.GlNameEn
                     })
                     .ToListAsync(cancellationToken);
                return vm;
            }
        }
    }
}

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
    public class GetGLByGlIdCustomerAndCustomerIdQuery: IRequest<GeneralLedgerDto>
    {
        public int Id { get; set; }
        public Guid CustomerId { get; set; }
        public class GetGLByGlIdCustomerAndCustomerIdQueryHandler : IRequestHandler<GetGLByGlIdCustomerAndCustomerIdQuery, GeneralLedgerDto>
        {
            private readonly IApplicationDbContext _context;

            public GetGLByGlIdCustomerAndCustomerIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<GeneralLedgerDto> Handle(GetGLByGlIdCustomerAndCustomerIdQuery request, CancellationToken cancellationToken)
            {
                var result = await _context.GeneralLedgers
                    .Where(g => g.GlIdByCustomer == request.Id && g.CustomerId == request.CustomerId && g.IsActive)
                    .Select(g => new GeneralLedgerDto
                    {
                        Id = g.Id,
                        GlIdByCustomer = g.GlIdByCustomer,
                        GLNameAr = g.GLNameAr,
                        GlNameEn = g.GlNameEn
                    })
                    .SingleOrDefaultAsync();

                return result;
            }
        }
    }
}

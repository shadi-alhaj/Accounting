using Accounting.Application.Common.Exceptions;
using Accounting.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Accounting.Application.Bonds.Queries.GetBonds
{
    public class GetBondByCustomerIdAndBondCustomerIdQuery: IRequest<BondDailyTransactionDto>
    {
        public Guid CustomerId { get; set; }
        public int BondUserId { get; set; }
        public int FinYear { get; set; }
        public class GetBondByCustomerIdAndBondCustomerIdQueryHandler : IRequestHandler<GetBondByCustomerIdAndBondCustomerIdQuery, BondDailyTransactionDto>
        {
            private readonly IApplicationDbContext _context;

            public GetBondByCustomerIdAndBondCustomerIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<BondDailyTransactionDto> Handle(GetBondByCustomerIdAndBondCustomerIdQuery request, CancellationToken cancellationToken)
            {
                var bondEntity = await _context.Bonds.Where(b => b.CustomerId == request.CustomerId && b.BondUserId == request.BondUserId && b.IsActive).SingleOrDefaultAsync();
                
                if(bondEntity == null)
                {
                    throw new NotFoundException(nameof(Bonds), request.BondUserId);
                }

                var hasDailyTrnasaction = await _context.DailyTransactions.AnyAsync(d => d.CustomerId == request.CustomerId && d.BondId == bondEntity.Id && d.DailyTransactionYear == request.FinYear && d.IsActive);

                var maxSNo = bondEntity.IntialSNo;
                if (hasDailyTrnasaction)
                {
                    maxSNo = _context.DailyTransactions.Where(d => d.CustomerId == request.CustomerId && d.BondId == bondEntity.Id && d.DailyTransactionYear == request.FinYear && d.IsActive).Max(d => d.DailyTransactionBondSNo) + 1;
                }

                return new BondDailyTransactionDto
                {
                    BondId = bondEntity.Id,
                    BondNameAr = bondEntity.BondNameAr,
                    BondNameEn = bondEntity.BondNameEn,
                    BondMaxSNo = maxSNo
                };
            }
        }
    }
}

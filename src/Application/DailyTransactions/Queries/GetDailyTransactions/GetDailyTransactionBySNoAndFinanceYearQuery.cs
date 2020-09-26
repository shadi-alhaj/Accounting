using Accounting.Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Accounting.Application.DailyTransactions.Queries.GetDailyTransactions
{
    public class GetDailyTransactionBySNoAndFinanceYearQuery: IRequest<DailyTransactionVm>
    {
        public Guid CustomerId { get; set; }
        public int FinanceYear { get; set; }
        public int BondSNo { get; set; }
        public class GetDailyTransactionBySNoAndFinanceYearQueryHandler : IRequestHandler<GetDailyTransactionBySNoAndFinanceYearQuery, DailyTransactionVm>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public GetDailyTransactionBySNoAndFinanceYearQueryHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<DailyTransactionVm> Handle(GetDailyTransactionBySNoAndFinanceYearQuery request, CancellationToken cancellationToken)
            {
                var vm = new DailyTransactionVm();

                vm.Lists = await _context.DailyTransactions.Where(d => d.CustomerId == request.CustomerId &&
                d.DailyTransactionYear == request.FinanceYear &&
                d.DailyTransactionBondSNo == request.BondSNo)
                    .Include(d => d.Bond).Include(d => d.DetailAccount)
                    .Select(d => new DailyTransactionDto
                    {
                        Id = d.Id,
                        DailyTransactionIdByCustomer = d.DailyTransactionIdByCustomer,
                        DailyTransactionBondSNo = d.DailyTransactionBondSNo,
                        DailyTransactionDate = d.DailyTransactionDate,
                        DailyTransactionMonth = d.DailyTransactionMonth,
                        DailyTransactionYear = d.DailyTransactionYear,
                        DailyTransactionDebitAmount = d.DailyTransactionDebitAmount,
                        DailyTransactionCreditAmount = d.DailyTransactionCreditAmount,
                        DailyTransactionDescription = d.DailyTransactionDescription,
                        CustomerId = d.CustomerId,
                        BondId = d.BondId,
                        BondUserId = d.Bond.BondUserId,
                        BondName = d.Bond.BondNameAr,
                        DetailAccountId = d.DetailAccountId,
                        DetailAccountIdByCustomer = d.DetailAccount.DetailAccountIdByCustomer,
                        DetailAccountNameAr = d.DetailAccount.DetailAccountNameAr,
                        GeneralLedgerId = d.GeneralLedgerId,
                        MainAccountId = d.MainAccountId,
                        TotalAccountId = d.TotalAccountId
                    }).ToListAsync(cancellationToken);

                return vm;
            }
        }
    }
}

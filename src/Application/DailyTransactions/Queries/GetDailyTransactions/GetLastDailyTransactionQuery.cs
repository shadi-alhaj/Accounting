using Accounting.Application.Common.Interfaces;
using AutoMapper;
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
    public class GetLastDailyTransactionQuery : IRequest<DailyTransactionVm>
    {
        public Guid CustomerId { get; set; }
        public int FinanceYear { get; set; }
        public class GetLastDailyTransactionQueryHandler : IRequestHandler<GetLastDailyTransactionQuery, DailyTransactionVm>
        {
            private readonly IApplicationDbContext _context;
            public GetLastDailyTransactionQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<DailyTransactionVm> Handle(GetLastDailyTransactionQuery request, CancellationToken cancellationToken)
            {
                var bondSno = _context.DailyTransactions.Where(d => d.CustomerId == request.CustomerId && d.DailyTransactionYear == request.FinanceYear).Select(d => d.DailyTransactionBondSNo).Max();

                var vm = new DailyTransactionVm();

                vm.Lists = await _context.DailyTransactions.Where(d => d.CustomerId == request.CustomerId &&
                d.DailyTransactionYear == request.FinanceYear &&
                d.DailyTransactionBondSNo == bondSno)
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

using Accounting.Application.Common.Interfaces;
using Accounting.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Accounting.Application.DailyTransactions.Commands.CreateCommand
{
    public partial class CreateDailyTransactionCommand : IRequest<Guid>
    {
        public CreateDailyTransactionCommand()
        {
            DailyTransactionDetailsList = new List<DailyTransactionDetailsDto>();
        }

        public int DailyTransactionIdByCustomer { get; set; }
        public Guid CustomerId { get; set; }
        public Guid BondId { get; set; }
        public int DailyTransactionBondSNo { get; set; }
        public DateTime DailyTransactionDate { get; set; }
        public int DailyTransactionMonth { get; set; }
        public int DailyTransactionYear { get; set; }
        public List<DailyTransactionDetailsDto> DailyTransactionDetailsList { get; set; }

        public class CreateDailyTransactionCommandHandler : IRequestHandler<CreateDailyTransactionCommand, Guid>
        {
            private readonly IApplicationDbContext _context;
            public CreateDailyTransactionCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Guid> Handle(CreateDailyTransactionCommand request, CancellationToken cancellationToken)
            {
                Guid id = Guid.NewGuid();
                foreach (var item in request.DailyTransactionDetailsList)
                {
                    var entity = new DailyTransaction
                    {
                        DailyTransactionIdByCustomer = request.DailyTransactionIdByCustomer,
                        DailyTransactionBondSNo = request.DailyTransactionBondSNo,
                        DailyTransactionDate = request.DailyTransactionDate,
                        DailyTransactionMonth = request.DailyTransactionMonth,
                        DailyTransactionYear = request.DailyTransactionYear,
                        CustomerId = request.CustomerId,
                        BondId = request.BondId,
                        DailyTransactionDebitAmount = item.DailyTransactionDebitAmount,
                        DailyTransactionCreditAmount = item.DailyTransactionCreditAmount,
                        DailyTransactionDescription = item.DailyTransactionDescription,
                        GeneralLedgerId = item.GeneralLedgerId,
                        MainAccountId = item.MainAccountId,
                        TotalAccountId = item.TotalAccountId,
                        DetailAccountId = item.DetailAccountId
                    };

                    _context.DailyTransactions.Add(entity);
                    id = entity.Id;
                }



                await _context.SaveChangesAsync(cancellationToken);

                return id;
            }
        }
    }
}
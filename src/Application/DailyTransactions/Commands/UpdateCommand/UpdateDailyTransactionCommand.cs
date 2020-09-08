using Accounting.Application.Common.Exceptions;
using Accounting.Application.Common.Interfaces;
using Accounting.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Accounting.Application.DailyTransactions.Commands.UpdateCommand
{
    public class UpdateDailyTransactionCommand : IRequest
    {
        public Guid Id { get; set; }
        public DateTime DailyTransactionDate { get; set; }
        public int DailyTransactionMonth { get; set; }
        public decimal DailyTransactionDebitAmount { get; set; }
        public decimal DailyTransactionCreditAmount { get; set; }
        public string DailyTransactionDescription { get; set; }       
        
        public Guid DetailAccountId { get; set; }
        public Guid TotalAccountId { get; set; }
        public Guid MainAccountId { get; set; }
        public Guid GeneralLedgerId { get; set; }

        public class UpdateDailyTransactionCommandHandler : IRequestHandler<UpdateDailyTransactionCommand>
        {
            private readonly IApplicationDbContext _context;

            public UpdateDailyTransactionCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(UpdateDailyTransactionCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.DailyTransactions.FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(DailyTransaction), request.Id);
                }

                entity.DailyTransactionDate = request.DailyTransactionDate;
                entity.DailyTransactionDescription = request.DailyTransactionDescription;
                entity.DetailAccountId = request.DetailAccountId;
                entity.TotalAccountId = request.TotalAccountId;
                entity.GeneralLedgerId = request.GeneralLedgerId;

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}

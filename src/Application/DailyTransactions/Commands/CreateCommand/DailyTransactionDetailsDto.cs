using System;

namespace Accounting.Application.DailyTransactions.Commands.CreateCommand
{
    public partial class CreateDailyTransactionCommand
    {
        public class DailyTransactionDetailsDto
        {
            public decimal DailyTransactionDebitAmount { get; set; }
            public decimal DailyTransactionCreditAmount { get; set; }
            public string DailyTransactionDescription { get; set; }         
            public Guid DetailAccountId { get; set; }
            public Guid TotalAccountId { get; set; }
            public Guid MainAccountId { get; set; }
            public Guid GeneralLedgerId { get; set; }
        }
    }
}
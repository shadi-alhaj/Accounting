using Accounting.Application.Common.Mappings;
using Accounting.Domain.Entities;
using System;

namespace Accounting.Application.DailyTransactions.Queries.GetDailyTransactions
{
    public class DailyTransactionDto : IMapFrom<DailyTransaction>
    {
        public Guid Id { get; set; }
        public int DailyTransactionIdByCustomer { get; set; }
        public int DailyTransactionBondSNo { get; set; }
        public DateTime DailyTransactionDate { get; set; }
        public int DailyTransactionMonth { get; set; }
        public int DailyTransactionYear { get; set; }
        public decimal DailyTransactionDebitAmount { get; set; }
        public decimal DailyTransactionCreditAmount { get; set; }
        public string DailyTransactionDescription { get; set; }
        public bool IsActive { get; set; }
        public Guid CustomerId { get; set; }
        public Guid BondId { get; set; }
        public int BondUserId { get; set; }
        public string BondName { get; set; }
        public Guid DetailAccountId { get; set; }
        public int DetailAccountIdByCustomer { get; set; }
        public string DetailAccountNameAr { get; set; }
        public string DetailAccountNameEn { get; set; }
        public Guid TotalAccountId { get; set; }
        public Guid MainAccountId { get; set; }
        public Guid GeneralLedgerId { get; set; }


    }
}

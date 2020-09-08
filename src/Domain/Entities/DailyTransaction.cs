using Accounting.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Domain.Entities
{
    public class DailyTransaction: AuditableEntity
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
        public Guid DetailAccountId { get; set; }
        public Guid TotalAccountId { get; set; }
        public Guid MainAccountId { get; set; }
        public Guid GeneralLedgerId { get; set; }

        public Customer Customer { get; set; }
        public Bond Bond { get; set; }
        public DetailAccount DetailAccount { get; set; }
        public MainAccount MainAccount { get; set; }
        public TotalAccount TotalAccount { get; set; }
        public GeneralLedger GeneralLedger { get; set; }


    }
}

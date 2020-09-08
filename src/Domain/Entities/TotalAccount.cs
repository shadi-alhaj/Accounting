using Accounting.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Domain.Entities
{
    public class TotalAccount : AuditableEntity
    {
        public TotalAccount()
        {
            DetailAccounts = new List<DetailAccount>();
            DailyTransactions = new List<DailyTransaction>();
        }
        public Guid Id { get; set; }
        public int TotalAccountIdByCustomer { get; set; }
        public string TotalAccountNameAr { get; set; }
        public string TotalAccountNameEn { get; set; }
        public Guid CustomerId { get; set; }
        public Guid GeneralLeadgerId { get; set; }
        public Guid MainAccountId { get; set; }
        public bool IsClose { get; set; }
        public bool IsActive { get; set; }
        public Customer Customer { get; set; }
        public GeneralLedger GeneralLedger { get; set; }
        public MainAccount MainAccount { get; set; }
        public IList<DetailAccount> DetailAccounts { get; set; }
        public IList<DailyTransaction> DailyTransactions { get; set; }
    }
}

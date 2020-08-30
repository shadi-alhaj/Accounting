using Accounting.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Domain.Entities
{
    public class MainAccount: AuditableEntity
    {
        public MainAccount()
        {
            TotalAccounts = new List<TotalAccount>();
        }
        public Guid Id { get; set; }       
        public int MainAccountIdByCustomer { get; set; }
        public string MainAccountNameAr { get; set; }
        public string MainAccountNameEn { get; set; }
        public Guid CustomerId { get; set; }
        public Guid GeneralLeadgerId { get; set; }
        public bool IsActive { get; set; }
        public Customer Customer { get; set; }
        public GeneralLedger GeneralLedger { get; set; }

        public List<TotalAccount> TotalAccounts { get; set; }
    }
}

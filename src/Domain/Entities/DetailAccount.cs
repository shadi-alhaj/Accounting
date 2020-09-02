using Accounting.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Domain.Entities
{
    public class DetailAccount: AuditableEntity
    {
        public Guid Id { get; set; }
        public int DetailAccountIdByCustomer { get; set; }
        public string DetailAccountNameAr { get; set; }
        public string DetailAccountNameEn { get; set; }
        public Guid CustomerId { get; set; }
        public Guid GeneralLeadgerId { get; set; }
        public Guid MainAccountId { get; set; }
        public Guid TotalAccountId { get; set; }
        public bool IsActive { get; set; }
        public Customer Customer { get; set; }
        public GeneralLedger GeneralLedger { get; set; }
        public MainAccount MainAccount { get; set; }
        public TotalAccount TotalAccount { get; set; }
    }
}

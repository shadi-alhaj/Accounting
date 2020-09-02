using Accounting.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Domain.Entities
{
    public class GeneralLedger: AuditableEntity
    {
        public GeneralLedger()
        {
            MainAccounts = new List<MainAccount>();
            TotalAccounts = new List<TotalAccount>();
            DetailAccounts = new List<DetailAccount>();
        }
        public Guid Id { get; set; }
        public int GlIdByCustomer { get; set; }
        public string GLNameAr { get; set; }
        public string GlNameEn { get; set; }
        public Guid CustomerId { get; set; }
        public bool IsActive { get; set; }
        public Customer Customer { get; set; }
        public IList<MainAccount> MainAccounts { get; set; }
        public IList<TotalAccount> TotalAccounts { get; set; }
        public IList<DetailAccount> DetailAccounts { get; set; }

    }
}

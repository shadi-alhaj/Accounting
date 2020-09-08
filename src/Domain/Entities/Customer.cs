using Accounting.Domain.Common;
using System;
using System.Collections.Generic;

namespace Accounting.Domain.Entities
{
    public class Customer: AuditableEntity
    {
        public Customer()
        {
            FinanceYears = new List<FinanceYear>();
            Bonds = new List<Bond>();
            GeneralLedgers = new List<GeneralLedger>();
            MainAccounts = new List<MainAccount>();
            TotalAccounts = new List<TotalAccount>();
            DetailAccounts = new List<DetailAccount>();
            DailyTransactions = new List<DailyTransaction>();
        }
    
        public Guid Id { get; set; }
        public int CustomerId { get; set; }
        public string CustomerNameAr { get; set; }
        public string CustomerNameEn { get; set; }
        public string TaxNo { get; set; }
        public string FaxNo { get; set; }
        public string PhoneNo { get; set; }
        public string MobileNo1 { get; set; }
        public string MobileNo2 { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }

        public IList<FinanceYear> FinanceYears  { get; set; }
        public IList<Bond> Bonds { get; set; }
        public IList<GeneralLedger> GeneralLedgers { get; set; }
        public IList<MainAccount> MainAccounts { get; set; }
        public IList<TotalAccount> TotalAccounts { get; set; }
        public IList<DetailAccount> DetailAccounts { get; set; }
        public IList<DailyTransaction> DailyTransactions { get; set; }
    }
}

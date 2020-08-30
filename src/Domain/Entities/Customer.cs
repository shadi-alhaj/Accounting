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

        public List<FinanceYear> FinanceYears  { get; set; }
        public List<Bond> Bonds { get; set; }
        public List<GeneralLedger> GeneralLedgers { get; set; }
        public List<MainAccount> MainAccounts { get; set; }
        public List<TotalAccount> TotalAccounts { get; set; }
    }
}

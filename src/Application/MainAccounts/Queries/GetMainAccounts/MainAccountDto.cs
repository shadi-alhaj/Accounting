using Accounting.Application.Common.Mappings;
using Accounting.Domain.Entities;
using System;

namespace Accounting.Application.MainAccounts.Queries.GetMainAccounts
{
    public class MainAccountDto : IMapFrom<MainAccount>
    {
        public Guid Id { get; set; }
        public int MainAccountIdByCustomer { get; set; }
        public string MainAccountNameAr { get; set; }
        public string MainAccountNameEn { get; set; }
        public Guid CustomerId { get; set; }
        public Guid GeneralLeadgerId { get; set; }
        public int GlIdByCustomer { get; set; }
        public string GLNameAr { get; set; }
        public bool IsActive { get; set; }
       
    }
}

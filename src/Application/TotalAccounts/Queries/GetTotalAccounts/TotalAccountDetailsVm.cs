﻿using Accounting.Application.Common.Mappings;
using Accounting.Domain.Entities;
using System;

namespace Accounting.Application.TotalAccounts.Queries.GetTotalAccounts
{
    public class TotalAccountDetailsVm : IMapFrom<TotalAccount>
    {
        public Guid Id { get; set; }
        public int TotalAccountIdByCustomer { get; set; }
        public string TotalAccountNameAr { get; set; }
        public string TotalAccountNameEn { get; set; }
        public Guid CustomerId { get; set; }
        public Guid GeneralLeadgerId { get; set; }
        public Guid MainAccountId { get; set; }
        public bool IsClose { get; set; }
        public bool IsActive { get; set; }
        
    }
}

﻿using Accounting.Application.Common.Mappings;
using Accounting.Domain.Entities;
using System;

namespace Accounting.Application.DetailAccounts.Queries.GetDetailAccounts
{
    public class DetailAccountDto : IMapFrom<DetailAccount>
    {
        public Guid Id { get; set; }
        public int DetailAccountIdByCustomer { get; set; }
        public string DetailAccountNameAr { get; set; }
        public string DetailAccountNameEn { get; set; }
        public string TotalAccountNameAr { get; set; }
        public Guid CustomerId { get; set; }
        public Guid GeneralLeadgerId { get; set; }
        public Guid MainAccountId { get; set; }
        public Guid TotalAccountId { get; set; }
        public int TotalAccountIdByCustomer { get; set; }
        public bool IsActive { get; set; }

    }
}

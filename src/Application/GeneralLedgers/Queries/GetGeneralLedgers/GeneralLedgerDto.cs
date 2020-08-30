using Accounting.Application.Common.Mappings;
using Accounting.Domain.Entities;
using System;

namespace Accounting.Application.GeneralLedgers.Queries.GetGeneralLedgers
{
    public class GeneralLedgerDto : IMapFrom<GeneralLedger>
    {
        public Guid Id { get; set; }
        public int GlIdByCustomer { get; set; }
        public string GLNameAr { get; set; }
        public string GlNameEn { get; set; }
        public Guid CustomerId { get; set; }       
    }
}

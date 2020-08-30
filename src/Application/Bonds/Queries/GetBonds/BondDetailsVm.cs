using Accounting.Application.Bonds.Queries.GetBonds;
using Accounting.Application.Common.Mappings;
using Accounting.Domain.Entities;
using System;

namespace Accounting.Application.Bonds.Queries.GetBonds
{
    public class BondDetailsVm : IMapFrom<Bond>
    {
        public Guid Id { get; set; }
        public int BondUserId { get; set; }
        public int IntialSNo { get; set; }
        public string BondNameAr { get; set; }
        public string BondNameEn { get; set; }
        public bool IsActive { get; set; }
        public Guid CusId { get; set; }
        public int CustomerId { get; set; }
        public string CustomerNameAr { get; set; }
        public string CustomerNameEn { get; set; }
    }
}

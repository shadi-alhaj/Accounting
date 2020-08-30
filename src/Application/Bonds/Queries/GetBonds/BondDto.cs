using Accounting.Application.Common.Mappings;
using Accounting.Domain.Entities;
using System;

namespace Accounting.Application.Bonds.Queries.GetBonds
{
    public class BondDto : IMapFrom<Bond>
    {
        public Guid Id { get; set; }
        public int BondUserId { get; set; }
        public int IntialSNo { get; set; }
        public string BondNameAr { get; set; }
        public string BondNameEn { get; set; }
        public bool IsActive { get; set; }
        public Guid CusId { get; set; }        
        
    }
}

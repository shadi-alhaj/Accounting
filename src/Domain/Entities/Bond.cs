using Accounting.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Domain.Entities
{
    public class Bond: AuditableEntity
    {
        public Guid Id { get; set; }
        public int BondUserId { get; set; }
        public int IntialSNo { get; set; }
        public string BondNameAr { get; set; }
        public string BondNameEn { get; set; }
        public bool IsActive { get; set; }

        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}

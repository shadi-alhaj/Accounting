using Accounting.Domain.Common;
using System;

namespace Accounting.Domain.Entities
{
    public class FinanceYear : AuditableEntity
    {
        public Guid Id { get; set; }
        public int Year { get; set; }
        public bool IsActive { get; set; }
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}

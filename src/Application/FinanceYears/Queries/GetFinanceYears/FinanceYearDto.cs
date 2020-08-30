using Accounting.Application.Common.Mappings;
using Accounting.Domain.Entities;
using System;

namespace Accounting.Application.FinanceYears.Queries.GetFinanceYears
{
    public class FinanceYearDto 
    {
        public Guid Id { get; set; }
        public int Year { get; set; }
        public Guid cusId { get; set; }
        public int CustomerId { get; set; }
        public string CustomerNameAr { get; set; }
    }
}

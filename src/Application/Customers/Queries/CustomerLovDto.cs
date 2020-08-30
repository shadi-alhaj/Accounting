using Accounting.Application.Common.Mappings;
using Accounting.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Application.Customers.Queries
{
    public class CustomerLovDto : IMapFrom<Customer>
    {
        public Guid Id { get; set; }
        public string CustomerNameAr { get; set; }
        public string  CustomerNameEn { get; set; }
    }
}

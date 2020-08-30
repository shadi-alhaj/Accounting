using Accounting.Application.Common.Mappings;
using Accounting.Domain.Entities;
using System;

namespace Accounting.Application.Customers.Queries.GetCustomers
{
    public class CustomerDto : IMapFrom<Customer>
    {
        public Guid Id { get; set; }
        public int CustomerId { get; set; }
        public string CustomerNameAr { get; set; }
        public string CustomerNameEn { get; set; }
        public string TaxNo { get; set; }
        public string FaxNo { get; set; }
        public string PhoneNo { get; set; }
        public string MobileNo1 { get; set; }
        public string MobileNo2 { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
    }
}

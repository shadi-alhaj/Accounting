using Accounting.Application.Common.Interfaces;
using Accounting.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Accounting.Application.Customers.Commands.CreateCommand
{
    public class CreateCustomerCommand : IRequest<Guid>
    { 
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

        public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Guid>
        {
            private readonly IApplicationDbContext _context;
            public CreateCustomerCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Guid> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
            {
                var entity = new Customer
                {
                    CustomerNameAr = request.CustomerNameAr,
                    CustomerNameEn = request.CustomerNameEn,
                    TaxNo = request.TaxNo,
                    FaxNo = request.FaxNo,
                    PhoneNo = request.PhoneNo,
                    MobileNo1 = request.MobileNo1,
                    MobileNo2 = request.MobileNo2,
                    Country = request.Country,
                    City = request.City,
                    Address = request.Address,
                    Email = request.Email
                };               

                _context.Customers.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return entity.Id;
            }
        }
    }
}
using Accounting.Application.Common.Exceptions;
using Accounting.Application.Common.Interfaces;
using Accounting.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Accounting.Application.Customers.Commands.UpdateCommand
{
    public class UpdateCustomerCommand : IRequest
    {
        public Guid Id { get; set; }
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
   

        public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand>
        {
            private readonly IApplicationDbContext _context;

            public UpdateCustomerCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Customers.FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Customer), request.Id);
                }

                entity.CustomerNameAr = request.CustomerNameAr;
                entity.CustomerNameEn = request.CustomerNameEn;
                entity.FaxNo = request.FaxNo;
                entity.TaxNo = request.TaxNo;
                entity.PhoneNo = request.PhoneNo;
                entity.MobileNo1 = request.MobileNo1;
                entity.MobileNo2 = request.MobileNo2;
                entity.Country = request.Country;
                entity.City = request.City;
                entity.Address = request.Address;
                entity.Email = entity.Email;

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}

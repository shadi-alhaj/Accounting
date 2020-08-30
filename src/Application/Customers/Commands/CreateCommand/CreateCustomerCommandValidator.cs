using FluentValidation;

namespace Accounting.Application.Customers.Commands.CreateCommand
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            
             RuleFor(v => v.CustomerNameAr)
                 .NotEmpty().WithMessage("Customer Name (Ar) is required")
                 .MaximumLength(250).WithMessage("Customer Name (Ar) can not exceed 250 characters");

            RuleFor(v => v.CustomerNameEn)                
                .MaximumLength(250).WithMessage("Customer Name (En) can not exceed 250 characters");

            RuleFor(v => v.TaxNo)
                .MaximumLength(20).WithMessage("Tax No can not exceed 20 characters");

            RuleFor(v => v.FaxNo)
                .MaximumLength(20).WithMessage("Fax No can not exceed 20 characters");

            RuleFor(v => v.PhoneNo)
                .MaximumLength(20).WithMessage("Phone number can not exceed 20 characters");

            RuleFor(v => v.MobileNo1)
                .MaximumLength(14).WithMessage("Mobile No 1 can not exceed 14 characters");

            RuleFor(v => v.MobileNo2)
                .MaximumLength(14).WithMessage("Mobile No 2 can not exceed 14 characters");

            RuleFor(v => v.Country)
                .MaximumLength(100).WithMessage("Country can not exceed 100 characters");

            RuleFor(v => v.City)
                .MaximumLength(100).WithMessage("City can not exceed 100 characters");

            RuleFor(v => v.Address)
                .MaximumLength(250).WithMessage("Address can not exceed 250 characters");

            RuleFor(v => v.Email)
                .MaximumLength(100).WithMessage("Email can not exceed 100 characters");
        }
    }
}

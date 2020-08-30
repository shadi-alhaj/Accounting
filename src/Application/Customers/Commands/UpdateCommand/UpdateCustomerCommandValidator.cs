using FluentValidation;

namespace Accounting.Application.Customers.Commands.UpdateCommand
{
    public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerCommandValidator()
        {
            /// Add validation here for example...
            /// RuleFor(v => v.Name)
            ///     .NotEmpty();
        }
    }
}

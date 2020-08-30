using FluentValidation;

namespace Accounting.Application.MainAccounts.Commands.UpdateCommand
{
    public class UpdateMainAccountCommandValidator : AbstractValidator<UpdateMainAccountCommand>
    {
        public UpdateMainAccountCommandValidator()
        {
            /// Add validation here for example...
            /// RuleFor(v => v.Name)
            ///     .NotEmpty();
        }
    }
}

using FluentValidation;

namespace Accounting.Application.TotalAccounts.Commands.UpdateCommand
{
    public class UpdateTotalAccountCommandValidator : AbstractValidator<UpdateTotalAccountCommand>
    {
        public UpdateTotalAccountCommandValidator()
        {
            /// Add validation here for example...
            /// RuleFor(v => v.Name)
            ///     .NotEmpty();
        }
    }
}

using FluentValidation;

namespace Accounting.Application.DailyTransactions.Commands.UpdateCommand
{
    public class UpdateDailyTransactionCommandValidator : AbstractValidator<UpdateDailyTransactionCommand>
    {
        public UpdateDailyTransactionCommandValidator()
        {
            /// Add validation here for example...
            /// RuleFor(v => v.Name)
            ///     .NotEmpty();
        }
    }
}

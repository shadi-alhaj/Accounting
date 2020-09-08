using FluentValidation;

namespace Accounting.Application.DailyTransactions.Commands.CreateCommand
{
    public class CreateDailyTransactionCommandValidator : AbstractValidator<CreateDailyTransactionCommand>
    {
        public CreateDailyTransactionCommandValidator()
        {
            /// Add validation here for example...
            /// RuleFor(v => v.Name)
            ///     .NotEmpty();
        }
    }
}

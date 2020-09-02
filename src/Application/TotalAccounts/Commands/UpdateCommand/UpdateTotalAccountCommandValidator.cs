using FluentValidation;

namespace Accounting.Application.TotalAccounts.Commands.UpdateCommand
{
    public class UpdateTotalAccountCommandValidator : AbstractValidator<UpdateTotalAccountCommand>
    {
        public UpdateTotalAccountCommandValidator()
        {
            RuleFor(v => v.TotalAccountNameAr)
                .NotEmpty().WithMessage("Total Account Name (Ar) can't be empty")
                .MaximumLength(250).WithMessage("Total Account Name (Ar) can't exceed 250 characters");

            RuleFor(v => v.TotalAccountNameEn)
                .MaximumLength(250).WithMessage("Total Account Name (En) can't exceed 250 characters");
        }
    }
}

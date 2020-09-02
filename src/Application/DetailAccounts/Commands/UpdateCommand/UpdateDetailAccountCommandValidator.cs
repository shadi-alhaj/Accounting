using FluentValidation;

namespace Accounting.Application.DetailAccounts.Commands.UpdateCommand
{
    public class UpdateDetailAccountCommandValidator : AbstractValidator<UpdateDetailAccountCommand>
    {
        public UpdateDetailAccountCommandValidator()
        {
            RuleFor(v => v.DetailAccountNameAr)
                .NotEmpty().WithMessage("Detail Account Name (Ar) can't be empty")
                .MaximumLength(250).WithMessage("Detail Account Name (Ar) can't exceed 250 characters");

            RuleFor(v => v.DetailAccountNameEn)
                .MaximumLength(250).WithMessage("Detail Account Name (En) can't exceed 250 characters");
        }
    }
}

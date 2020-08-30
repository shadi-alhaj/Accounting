using FluentValidation;

namespace Accounting.Application.GeneralLedgers.Commands.UpdateCommand
{
    public class UpdateGeneralLedgerCommandValidator : AbstractValidator<UpdateGeneralLedgerCommand>
    {
        public UpdateGeneralLedgerCommandValidator()
        {
            RuleFor(v => v.GLNameAr)
                .NotEmpty().WithMessage("General Ledger Name (Ar) is required")
                .MaximumLength(250).WithMessage("General Ledger Name (Ar) can not exceed 250 characters");

            RuleFor(v => v.GlNameEn)
                .MaximumLength(250).WithMessage("General Ledger Name (En) can not exceed 250 characters");
        }
    }
}

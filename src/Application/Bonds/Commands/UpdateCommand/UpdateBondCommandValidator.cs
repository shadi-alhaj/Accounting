using FluentValidation;

namespace Accounting.Application.Bonds.Commands.UpdateCommand
{
    public class UpdateBondCommandValidator : AbstractValidator<UpdateBondCommand>
    {
        public UpdateBondCommandValidator()
        {
            RuleFor(v => v.IntialSNo)
                .GreaterThan(0).WithMessage("Bond Intial SNo should be greater than 0");

            RuleFor(v => v.BondNameAr)
                .NotEmpty().WithMessage("Bond Name (Ar) is required")
                .MaximumLength(250).WithMessage("Bond Name (Ar) can not exceed 250 characters");

            RuleFor(v => v.BondNameEn)
                .MaximumLength(250).WithMessage("Bond Name (En) can not exceed 250 characters");
        }
    }
}

using FluentValidation;

namespace Core.Application.Features.Commerce.Medicines.Commands.UpdateMedicine;

public class UpdateMedicineValidator : AbstractValidator<UpdateMedicineCommand>
{
    private UpdateMedicineValidator()
    {
        RuleFor(x => x.Name)
            .MaximumLength(50)
            .NotEmpty();
        RuleFor(x => x.Type)
            .IsInEnum();
        RuleFor(x => x.MeasureUnit)
            .IsInEnum();
        RuleFor(x => x.Volume)
            .GreaterThan(0)
            .NotEmpty();
        RuleFor(x => x.ManufacturerName)
            .MaximumLength(50)
            .NotEmpty();
        RuleFor(x => x.ManufacturerOrigin)
            .MaximumLength(50)
            .NotEmpty();
    }
}
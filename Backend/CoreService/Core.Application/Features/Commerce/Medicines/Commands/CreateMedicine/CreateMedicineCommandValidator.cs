using FluentValidation;

namespace Core.Application.Features.Commerce.Medicines.Commands.CreateMedicine;

public class CreateMedicineCommandValidator : AbstractValidator<CreateMedicineCommand>
{
    public CreateMedicineCommandValidator()
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
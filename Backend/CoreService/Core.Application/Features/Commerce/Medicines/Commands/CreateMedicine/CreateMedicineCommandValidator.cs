using Core.Domain.EntitiesConstraints.Commerce;
using FluentValidation;

namespace Core.Application.Features.Commerce.Medicines.Commands.CreateMedicine;

public class CreateMedicineCommandValidator : AbstractValidator<CreateMedicineCommand>
{
    public CreateMedicineCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MinimumLength(MedicineConstraint.MinNameLength)
            .MaximumLength(MedicineConstraint.MaxNameLength);

        RuleFor(x => x.Type)
            .IsInEnum();

        RuleFor(x => x.MeasureUnit)
            .IsInEnum();

        RuleFor(x => x.Volume)
            .GreaterThan(MedicineConstraint.MinVolume)
            .LessThan(MedicineConstraint.MaxVolume);

        RuleFor(x => x.ManufacturerName)
            .NotEmpty()
            .MinimumLength(MedicineConstraint.MinManufacterNameLength)
            .MaximumLength(MedicineConstraint.MaxManufacterOriginLength);

        RuleFor(x => x.ManufacturerOrigin)
            .NotEmpty()
            .MinimumLength(MedicineConstraint.MinManufacterOriginLength)
            .MaximumLength(MedicineConstraint.MaxManufacterOriginLength);
    }
}
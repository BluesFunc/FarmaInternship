using Core.Application.DTOs.Commerce;
using Core.Application.Wrappers;
using Core.Domain.Enums.Commerce;
using MediatR;

namespace Core.Application.Features.Commerce.Medicines.Commands.UpdateMedicine;

public class UpdateMedicineCommand : IRequest<Result<MedicineDto>>
{
    public Guid Id { get; init; }
    public string Name { get; init; } = null!;
    public MedicineType Type { get; init; }
    public MedicineMeasureUnit MeasureUnit { get; init; }
    public int Volume { get; init; }
    public string ManufacturerOrigin { get; init; } = null!;
    public string ManufacturerName { get; init; } = null!;
}
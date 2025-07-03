using Core.Application.Dtos.Commerce;
using Core.Application.Interfaces;
using Core.Application.Wrappers;
using Core.Domain.Enums.Commerce;
using MediatR;

namespace Core.Application.Features.Commerce.Medicines.Commands.UpdateMedicine;

public class UpdateMedicineCommand : IRequest<Result<MedicineDto>>, ITransactionRequest
{
    public Guid Id { get; init; }
    public required string Name { get; init; }
    public MedicineType Type { get; init; }
    public MedicineMeasureUnit MeasureUnit { get; init; }
    public int Volume { get; init; }
    public required string ManufacturerOrigin { get; init; }
    public required string ManufacturerName { get; init; }
}
using Core.Domain.Entities.Commerce;
using Core.Domain.Enums.Commerce;
using Mapster;

namespace Core.Application.Dtos.Commerce;

public record MedicineDto : IMapFrom<Medicine>
{
    public required string Name { get; init; }
    public MedicineType Type { get; init; }
    public MedicineMeasureUnit MeasureUnit { get; init; }
    public int Volume { get; init; }
    public required string ManufacturerOrigin { get; init; }
    public required string ManufacturerName { get; init; }
}
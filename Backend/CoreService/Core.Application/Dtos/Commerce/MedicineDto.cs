using Core.Domain.Entities.Commerce;
using Core.Domain.Enums.Commerce;
using Mapster;

namespace Core.Application.Dtos.Commerce;

public record MedicineDto : IMapFrom<Medicine>
{
    public string Name { get; init; } = null!;
    public MedicineType Type { get; init; }
    public MedicineMeasureUnit MeasureUnit { get; init; }
    public int Volume { get; init; }
    public string ManufacturerOrigin { get; init; } = null!;
    public string ManufacturerName { get; init; } = null!;
}
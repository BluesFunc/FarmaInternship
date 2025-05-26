 using Core.Domain.Entities.Abstractions;
using Core.Domain.Enums.Commerce;

namespace Core.Domain.Entities.Commerce;

public class Medicine : AuditableEntity
{
    public string Name { get; set; } = null!;
    public MedicineType Type { get; set; }
    public MedicineMeasureUnit MeasureUnit { get; set; }
    public int Volume { get; set; }
    public string ManufacturerOrigin { get; set; } = null!;
    public string ManufacturerName { get; set; } = null!;
}
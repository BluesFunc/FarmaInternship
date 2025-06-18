 using Core.Domain.Entities.Abstractions;
using Core.Domain.Enums.Commerce;

namespace Core.Domain.Entities.Commerce;

public class Medicine : AuditableEntity
{
    public required string Name { get; set; }
    public MedicineType Type { get; set; }
    public MedicineMeasureUnit MeasureUnit { get; set; }
    public int Volume { get; set; }
    public required string ManufacturerOrigin { get; set; } 
    public required string ManufacturerName { get; set; }
    public Product ProductItem { get; private set; }
}
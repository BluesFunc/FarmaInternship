using Core.Domain.Entities.Abstractions;

namespace Core.Domain.Entities.Commerce;

public class ProductCategory : AuditableEntity
{
    public string Name { get; set; } = null!;
    public IReadOnlyCollection<Product> Products { get; private set; } = null!;
}
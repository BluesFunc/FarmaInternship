using Core.Domain.Entities.Abstractions;

namespace Core.Domain.Entities.Commerce;

public class ProductCategory : AuditableEntity
{
    public required string Name { get; set; } 
    public IReadOnlyCollection<Product>  Products { get; private set; } 
}
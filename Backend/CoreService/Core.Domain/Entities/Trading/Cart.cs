using Core.Domain.Entities.Abstractions;
using Core.Domain.Entities.Commerce;
using Core.Domain.Enums.Trading;

namespace Core.Domain.Entities.Trading;

public class Cart : AuditableEntity
{
    public CartStatus Status { get; set; } = CartStatus.Active;
    public IReadOnlyCollection<Product> Products { get; private set; }
}
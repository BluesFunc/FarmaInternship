using Core.Domain.Entities.Abstractions;

namespace Core.Domain.Entities.Commerce;

public class Merchant : AuditableEntity
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public Guid AdminId { get; private set; }

    public IReadOnlyCollection<Product> Products { get; private set; }

    private Merchant()
    {
    }

    public Merchant(string name, Guid adminId)
    {
        Name = name;
        AdminId = adminId;
    }
}
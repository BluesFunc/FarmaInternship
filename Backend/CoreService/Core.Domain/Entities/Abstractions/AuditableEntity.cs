namespace Core.Domain.Entities.Abstractions;

public abstract class AuditableEntity: Entity
{
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
    public Guid CreatorId { get; protected set; }
    public Guid ModifierId { get; protected set; }
}
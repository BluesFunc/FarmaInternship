using System.ComponentModel.DataAnnotations;

namespace Core.Domain.Entities.Abstractions;

public abstract class Entity
{
    [Key] public virtual Guid Id { get; protected set; }
}
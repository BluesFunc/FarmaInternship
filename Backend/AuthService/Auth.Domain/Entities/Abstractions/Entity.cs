using System.Numerics;
using Microsoft.AspNetCore.Identity;

namespace Auth.Domain.Entities.Abstractions;

public abstract class Entity
{
    public virtual Guid Id { get; }
}
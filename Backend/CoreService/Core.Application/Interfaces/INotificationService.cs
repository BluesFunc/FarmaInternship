using Core.Domain.Entities.Abstractions;

namespace Core.Application.Interfaces;

public interface INotificationService<TEntity> where TEntity : Entity
{
    Task SendNotification(Guid userId, string message);
}
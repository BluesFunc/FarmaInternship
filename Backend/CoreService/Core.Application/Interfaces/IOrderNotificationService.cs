using Core.Domain.Entities.Trading;

namespace Core.Application.Interfaces;

public interface IOrderNotificationService : INotificationService<Order>;
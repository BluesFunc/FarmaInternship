using Core.Application.Interfaces;
using Core.Domain.Entities.Trading;
using Core.Infrastructure.Services.Notifications.Abstractions;
using Microsoft.AspNetCore.SignalR;

namespace Core.Infrastructure.Services.Notifications;

public class OrderNotificationService :NotificationService<OrderNotificationHub>, IOrderNotificationService
{
    public OrderNotificationService(IHubContext<OrderNotificationHub> hubContext) : base(hubContext)
    {
    }
}
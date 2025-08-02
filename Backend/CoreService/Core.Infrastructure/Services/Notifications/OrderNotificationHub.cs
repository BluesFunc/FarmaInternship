using Core.Domain.Entities.Trading;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace Core.Infrastructure.Services.Notifications.Abstractions;

public class OrderNotificationHub : NotificationHub
{
    public OrderNotificationHub(ILogger<NotificationHub> logger) : base(logger)
    {
    }
}
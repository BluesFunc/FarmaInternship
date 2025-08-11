using Microsoft.Extensions.Logging;

namespace Core.Infrastructure.Services.Notifications;

public class OrderNotificationHub : NotificationHub
{
    public OrderNotificationHub(ILogger<NotificationHub> logger) : base(logger)
    {
    }
}
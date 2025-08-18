using Core.Application.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace Core.Infrastructure.Services.Notifications;

public class OrderNotificationService : NotificationService<OrderNotificationHub>, IOrderNotificationService
{
    public OrderNotificationService(IHubContext<OrderNotificationHub> hubContext) : base(hubContext)
    {
    }
}
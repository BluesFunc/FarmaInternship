using Core.Domain.Entities.Abstractions;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace Core.Infrastructure.Services.Notifications;

public  class NotificationHub: Hub 
{
    private readonly ILogger<NotificationHub> _logger;

    public NotificationHub(ILogger<NotificationHub> logger)
    {
        _logger = logger;
    }

    public async Task Subscribe(Guid userId)
    {
        
        var groupName = $"user:{userId}";
         await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
         _logger.LogInformation($"[{Context.ConnectionId}] subscribed to group {groupName}");
    }

    public async Task Unsubscribe(Guid userId)
    {
        var groupName = $"user:{userId}";
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, $"user:{userId}");
        _logger.LogInformation($"[{Context.ConnectionId}] subscribed from group {groupName}");
    }
}
using Core.Application.Interfaces;
using Core.Domain.Entities.Abstractions;
using Microsoft.AspNetCore.SignalR;

namespace Core.Infrastructure.Services.Notifications;

public abstract class NotificationService<THub> where THub : NotificationHub
{
    private readonly IHubContext<THub> _hubContext;

    public NotificationService(IHubContext<THub> hubContext)
    {
        _hubContext = hubContext;
    }

    public async Task SendNotification(Guid userId, string message)
    {
        await _hubContext
            .Clients.Group($"user:{userId}")
            .SendAsync("OrderCreated", message);
       
    }
    }

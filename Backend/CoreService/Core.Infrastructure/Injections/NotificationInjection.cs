using Core.Application.Interfaces;
using Core.Domain.Entities.Trading;
using Core.Infrastructure.Services.Notifications;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Infrastructure.Injections;

public static class NotificationInjection
{
    public static IServiceCollection InjectNotification(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddCors(o => o.AddDefaultPolicy(p =>
            p.AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin()
                .AllowCredentials()));
        
        serviceCollection.AddSignalR(options =>
        {
            options.KeepAliveInterval = TimeSpan.FromSeconds(10);
            options.ClientTimeoutInterval = TimeSpan.FromSeconds(30);
        });
        
        serviceCollection.AddScoped<IOrderNotificationService, OrderNotificationService>();
        return serviceCollection;
    }
}
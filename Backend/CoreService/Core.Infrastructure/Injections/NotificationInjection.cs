using Core.Application.Interfaces;
using Core.Infrastructure.Services.Notifications;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Infrastructure.Injections;

public static class NotificationInjection
{
    public static IServiceCollection InjectNotification(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSignalR(options =>
        {
            options.KeepAliveInterval = TimeSpan.FromSeconds(10);
            options.ClientTimeoutInterval = TimeSpan.FromSeconds(30);
        });

        serviceCollection.AddScoped<IOrderNotificationService, OrderNotificationService>();
        return serviceCollection;
    }
}
using System.Text.Json;
using Analytics.DAL.Collections;
using Analytics.DAL.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Analytics.BLL.Handlers.Brokers;

public class UserConsumerHandler : IKafkaMessageHandler
{
    public UserConsumerHandler(IServiceProvider serviceProvider)
    {
        ServiceProvider = serviceProvider;
    }

    public string Topic { get; } = "user_statistic";
    private IServiceProvider ServiceProvider { get; }

    public async Task HandleAsync(string key, string message, CancellationToken cancellationToken)
    {
        using var scope = ServiceProvider.CreateScope();
        var service = scope.ServiceProvider.GetRequiredService<IRepository<UserStatistic>>();

        var messageData = JsonSerializer.Deserialize<UserStatisticMessage>(message);
        var userStatistic = await service.GetModelByIdAsync(messageData.UserId);

        if (userStatistic is null)
        {
            var newModel = new UserStatistic(messageData.UserId);
            await service.AddModelAsync(newModel);
        }
        else
        {
            userStatistic.TotalMoneySpend += messageData.TotalRevenue;
            userStatistic.TotalOrders += 1;
            await service.UpdateModelAsync(userStatistic);
        }
    }
}
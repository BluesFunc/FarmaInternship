using System.Text.Json;
using Analytics.DAL.Collections;
using Analytics.DAL.Collections.Abstractions;
using Analytics.DAL.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Analytics.BLL.Handlers.Brokers.Merchants;

public class MerchantConsumerHandler : IKafkaMessageHandler
{
    public string Topic { get; } = "merchant_statistic";
    private IServiceProvider ServiceProvider { get; }


    public MerchantConsumerHandler(IServiceProvider serviceProvider)
    {
        ServiceProvider = serviceProvider;
    }

    public async Task HandleAsync(string key, string message, CancellationToken cancellationToken)
    {
        using var scope = ServiceProvider.CreateScope();
        var service = scope.ServiceProvider.GetRequiredService<IRepository<MerchandiserStatistic>>();

        var messageData = JsonSerializer.Deserialize<MerchantStatisticMessage>(message);
        var merchandiserStatistic = await service.GetModelByIdAsync(messageData.MerchandiserId);

        if (merchandiserStatistic is null)
        {
            var newModel = new MerchandiserStatistic(messageData.MerchandiserId){MonthlyRevenue = (decimal)messageData.MonthlyRevenue};
            await service.AddModelAsync(newModel);
        }
        else
        {
            merchandiserStatistic.MonthlyRevenue += (decimal)messageData.MonthlyRevenue;
            await service.UpdateModelAsync(merchandiserStatistic);
        }
        
    }
}
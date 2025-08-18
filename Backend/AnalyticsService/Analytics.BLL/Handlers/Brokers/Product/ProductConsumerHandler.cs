using System.Text.Json;
using Analytics.DAL.Collections.Abstractions;
using Analytics.DAL.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Analytics.BLL.Handlers.Brokers.Product;

public class ProductConsumerHandler : IKafkaMessageHandler
{
    public string Topic { get; } = "product_statistic";
    private IServiceProvider ServiceProvider { get; }

    public ProductConsumerHandler(IServiceProvider serviceProvider)
    {
        ServiceProvider = serviceProvider;
    }

    public async Task HandleAsync(string key, string message, CancellationToken cancellationToken)
    {
        using var scope = ServiceProvider.CreateScope();
        var service = scope.ServiceProvider.GetRequiredService<IRepository<ProductStatistic>>();

        var messageData = JsonSerializer.Deserialize<ProductStatisticMessage>(message);
        var productStatistic = await service.GetModelByIdAsync(messageData.ProductId);

        if (productStatistic is null)
        {
            var newModel = new ProductStatistic(messageData.ProductId) { };
            await service.AddModelAsync(newModel);
        }
        else
        {
            productStatistic.ViewCount += 1;
            await service.UpdateModelAsync(productStatistic);
        }
    }
}
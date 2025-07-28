using Analytics.BLL.Handlers.Brokers;
using Analytics.BLL.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Analytics.BLL;

public static class BllConfiguration
{
    public static IServiceCollection ConfigureBusinessLogicLayer(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddHostedService< KafkaConsumerService>();
        serviceCollection.AddSingleton<IKafkaMessageHandler, UserConsumerHandler>();
        return serviceCollection;
    }
}
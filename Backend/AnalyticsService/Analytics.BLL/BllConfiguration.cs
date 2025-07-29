using Analytics.BLL.Handlers.Brokers;
using Analytics.BLL.Handlers.Brokers.Merchants;
using Analytics.BLL.Handlers.Brokers.Product;
using Analytics.BLL.Handlers.Brokers.Users;
using Analytics.BLL.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Analytics.BLL;

public static class BllConfiguration
{
    public static IServiceCollection ConfigureBusinessLogicLayer(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddHostedService<KafkaConsumerService>();
        serviceCollection.AddSingleton<IKafkaMessageHandler, UserConsumerHandler>();
        serviceCollection.AddSingleton<IKafkaMessageHandler, MerchantConsumerHandler>();
        serviceCollection.AddSingleton<IKafkaMessageHandler, ProductConsumerHandler>();

        return serviceCollection;
    }
}
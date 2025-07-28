using Confluent.Kafka;
using Core.Application.Interfaces;
using Core.Infrastructure.Services.Statistics;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Infrastructure.Injections;

public static class BrokerInjection
{
    public static IServiceCollection InjectBroker(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<IStatisticMessageProducer, StatisticMessageProducer>(x =>
            new StatisticMessageProducer(new ProducerConfig { BootstrapServers = "localhost:9092", MessageTimeoutMs = 5000}));
        return serviceCollection;
    }
}
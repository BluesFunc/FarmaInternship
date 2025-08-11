using Confluent.Kafka;
using Core.Application.Interfaces.Statistics;
using Core.Infrastructure.Services.Statistics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Infrastructure.Injections;

public static class BrokerInjection
{
    public static IServiceCollection InjectBroker(this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        serviceCollection.AddSingleton<IStatisticMessageProducer, StatisticMessageProducer>(x =>
            new StatisticMessageProducer(new ProducerConfig
            {
                BootstrapServers = Environment.GetEnvironmentVariable("KAFKA_HOST") ??
                                   throw new InvalidOperationException(),
                MessageTimeoutMs = int.Parse(Environment.GetEnvironmentVariable("KAFKA_MESSAGE_TIMEOUT") ??
                                             throw new InvalidOperationException())
            }));
        return serviceCollection;
    }
}
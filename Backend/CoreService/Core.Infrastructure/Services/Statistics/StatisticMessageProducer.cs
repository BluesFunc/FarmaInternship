using Confluent.Kafka;
using Core.Application.Interfaces.Statistics;

namespace Core.Infrastructure.Services.Statistics;

public class StatisticMessageProducer : IStatisticMessageProducer
{
    private IProducer<string, string> _producer;

    public StatisticMessageProducer(ProducerConfig config)
    {
        _producer = new ProducerBuilder<string, string>(config).Build();
    }

    public async Task SendMessageAsync(string topic, string message, CancellationToken cancellationToken)
    {
        await _producer.ProduceAsync(topic, new Message<string, string>() { Value = message }, cancellationToken);
    }
}
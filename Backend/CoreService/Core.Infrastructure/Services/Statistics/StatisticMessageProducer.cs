using Confluent.Kafka;
using Core.Application.Interfaces;

namespace Core.Infrastructure.Services.Statistics;

public class StatisticMessageProducer : IStatisticMessageProducer
{
    private IProducer<Null, string> _producer;

    public StatisticMessageProducer(ProducerConfig config)
    {
    
        _producer = new ProducerBuilder<Null, string>(config).Build();
    }

    public async Task SendMessageAsync(string topic, string message)
    {
        await _producer.ProduceAsync(topic, new Message<Null, string>() { Value = message });
    }
}
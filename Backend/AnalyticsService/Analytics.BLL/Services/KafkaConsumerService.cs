using System.Text.Json;
using Analytics.BLL.Handlers.Brokers;
using Confluent.Kafka;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Analytics.BLL.Services;

public class KafkaConsumerService : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;

    private readonly string bootstrapServers = Environment.GetEnvironmentVariable("KAFKA_URL")
                                               ?? throw new InvalidOperationException();

    private readonly ILogger<KafkaConsumerService> _logger;
    private readonly IEnumerable<IKafkaMessageHandler> _handlers;

    public KafkaConsumerService(
        IServiceProvider serviceProvider,
        ILogger<KafkaConsumerService> logger,
        IEnumerable<IKafkaMessageHandler> handlers)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
        _handlers = handlers;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        Task.Run(() => ConsumeLoop(stoppingToken), stoppingToken);
        return Task.CompletedTask;
    }

    private async Task ConsumeLoop(CancellationToken stoppingToken)
    {
        var config = new ConsumerConfig
        {
            BootstrapServers = bootstrapServers,
            GroupId = "statistic",
            AutoOffsetReset = AutoOffsetReset.Earliest
        };

        using var consumer = new ConsumerBuilder<string, string>(config).Build();


        var topics = _handlers.Select(h => h.Topic).Distinct().ToList();
        consumer.Subscribe(topics);

        _logger.LogInformation("Kafka consumer started. Subscribed to topics: {Topics}", string.Join(", ", topics));

        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                var result = consumer.Consume(stoppingToken);
                var topic = result.Topic;
                var message = result.Message.Value;
                var key = result.Message.Key;

                var handler = _handlers.FirstOrDefault(h => h.Topic == topic);
                if (handler != null)
                {
                    _logger.LogInformation("Message received on topic {Topic}", topic);
                    await handler.HandleAsync(key, message, stoppingToken);
                }
                else
                {
                    _logger.LogWarning("No handler found for topic: {Topic}", topic);
                }
            }
            catch (JsonException ex)
            {
                _logger.LogError(ex, "Could not serialize/deserialize message");
            }
            catch (ConsumeException ex)
            {
                _logger.LogError(ex, "Error consuming Kafka message.");
            }
            catch (OperationCanceledException)
            {
                _logger.LogInformation("Kafka consumer shutting down...");
            }
         
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled error in Kafka consumer loop.");
            }
        }

        consumer.Close();
        _logger.LogInformation("Kafka consumer stopped.");
    }
}
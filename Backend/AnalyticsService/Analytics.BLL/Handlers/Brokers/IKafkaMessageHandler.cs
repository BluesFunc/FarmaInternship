namespace Analytics.BLL.Handlers.Brokers;

public interface IKafkaMessageHandler
{
    string Topic { get; }
    public Task HandleAsync(string key, string message, CancellationToken cancellationToken);
} 
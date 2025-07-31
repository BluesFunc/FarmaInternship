namespace Core.Application.Interfaces.Statistics;

public interface IStatisticMessageProducer
{
    public Task SendMessageAsync(string topic, string message, CancellationToken cancellationToken);
}
namespace Core.Application.Interfaces;

public interface IStatisticMessageProducer
{
    public Task SendMessageAsync(string topic, string message, CancellationToken cancellationToken);
}
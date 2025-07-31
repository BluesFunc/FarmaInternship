namespace Core.Application.Dtos.Statistics.Messages;

public class ProductStatisticMessage : IBrokerMessage
{
    public required Guid ProductId { get; init; }
    public long ViewCount { get; set; }
}
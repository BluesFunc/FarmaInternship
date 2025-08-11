namespace Core.Application.Dtos.Statistics.Messages;

public class UserStatisticMessage : IBrokerMessage
{
    public Guid UserId { get; init; }
    public ulong TotalRevenue { get; set; }
    public ulong OrderCreated { get; set; }
}
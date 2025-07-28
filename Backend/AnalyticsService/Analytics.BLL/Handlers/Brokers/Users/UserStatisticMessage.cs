namespace Analytics.BLL.Handlers.Brokers;

public record UserStatisticMessage
{
    public Guid UserId { get; init; }
    public int TotalRevenue { get; init;} 
    public int OrderCreated { get; init; }
}
namespace Core.Application.Dtos.Statistics;

public class UserStatisticMessage : IBrokerMessage
{
    public Guid UserId { get; init; }
    public int TotalRevenue { get; set;} 
    public int OrderCreated { get; set; }
}
namespace Core.Application.Dtos.Statistics.Messages;

public class MerchantStatisticMessage : IBrokerMessage
{
    public Guid MerchandiserId { get; set; }
    public double MonthlyRevenue { get; set; }
}
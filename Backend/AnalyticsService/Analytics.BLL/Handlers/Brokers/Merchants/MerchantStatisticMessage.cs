namespace Analytics.BLL.Handlers.Brokers.Merchants;

public class MerchantStatisticMessage
{
    public Guid MerchandiserId { get; init; }
    public double MonthlyRevenue { get; init; }
}
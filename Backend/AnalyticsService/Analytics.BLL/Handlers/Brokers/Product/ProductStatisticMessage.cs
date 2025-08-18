namespace Analytics.BLL.Handlers.Brokers.Product;

public class ProductStatisticMessage
{
    public Guid ProductId { get; init; }
    public long ViewCount { get; set; }
}
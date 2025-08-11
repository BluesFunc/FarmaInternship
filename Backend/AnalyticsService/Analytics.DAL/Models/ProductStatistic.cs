using MongoDB.Bson.Serialization.Attributes;

namespace Analytics.DAL.Models;

public class ProductStatistic : IModel
{
    [BsonId] public Guid ProductId { get; init; }
    public long ViewCount { get; set; } = 0;

    public ProductStatistic(Guid productId)
    {
        ProductId = productId;
    }

    public Guid GetId()
    {
        return ProductId;
    }
}
using MongoDB.Bson.Serialization.Attributes;

namespace Analytics.DAL.Models;

public class ProductStatistic : IModel 
{ 
    [BsonId]
    public Guid ProductId { get; init; }
    public  Guid MerchandiserId { get; init; }
    public long SoldCount { get; set; }
    public long ViewCount { get; set; }

    public Guid GetId()
    {
        return ProductId;
    }
}
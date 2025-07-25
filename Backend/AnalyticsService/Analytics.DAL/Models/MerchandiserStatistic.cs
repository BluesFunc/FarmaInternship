using MongoDB.Bson.Serialization.Attributes;

namespace Analytics.DAL.Models;

public class MerchandiserStatistic
{
    [BsonId]
    public Guid MerchandiserId { get; init; }
    public decimal MonthlyRevenue { get; init; }
    public List<Guid> MostPopularProducts { get; private set; } = [];
}
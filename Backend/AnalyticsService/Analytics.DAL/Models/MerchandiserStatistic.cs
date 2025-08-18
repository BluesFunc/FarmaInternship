using MongoDB.Bson.Serialization.Attributes;

namespace Analytics.DAL.Models;

public class MerchandiserStatistic : IModel
{
    [BsonId] public Guid MerchandiserId { get; init; }
    public decimal MonthlyRevenue { get; set; }

    public MerchandiserStatistic(Guid merchandiserId)
    {
        MerchandiserId = merchandiserId;
    }

    public Guid GetId()
    {
        return MerchandiserId;
    }
}
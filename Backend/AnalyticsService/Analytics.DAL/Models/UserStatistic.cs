using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Analytics.DAL.Models;

public class UserStatistic : IModel
{
    [BsonId]
    public Guid UserId { get; private set; }
    public long TotalMoneySpend { get; set; } = 0;
    public long TotalOrders { get; set; } = 1;

    public UserStatistic(Guid userId)
    {
        UserId = userId;
    }

    public Guid GetId()
    {
        return UserId;
    }
}
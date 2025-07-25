using Analytics.DAL.Models;
using MongoDB.Driver;

namespace Analytics.DAL.Collections;

public class UserService
{
    public readonly IMongoCollection<UserStatistic> Collection;

    public UserService(IMongoDatabase database)
    {
        Collection = database.GetCollection<UserStatistic>("users");
    }

}
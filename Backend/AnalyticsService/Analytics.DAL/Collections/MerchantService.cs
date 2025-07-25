using Analytics.DAL.Models;
using MongoDB.Driver;

namespace Analytics.DAL.Collections;

public class MerchantService
{
    
    public readonly IMongoCollection<MerchandiserStatistic> Collection;

    public MerchantService(IMongoDatabase database)
    {
        Collection = database.GetCollection<MerchandiserStatistic>("merchandisers");
    }
}
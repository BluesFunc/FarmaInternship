using Analytics.DAL.Collections.Abstractions;
using Analytics.DAL.Models;
using MongoDB.Driver;

namespace Analytics.DAL.Collections;

public class MerchantService(IMongoDatabase database)
    : RepositoryBase<MerchandiserStatistic>(database, "merchandisers");
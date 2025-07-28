using Analytics.DAL.Collections;
using Analytics.DAL.Models;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;

namespace Analytics.DAL;

public  static class DataLayerConfiguration
{
    public static IServiceCollection ConfigureDal(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton(
            new MongoClient(Environment.GetEnvironmentVariable("STATISTIC_DB"))
                .GetDatabase(Environment.GetEnvironmentVariable("STATISTIC_DB_NAME")));
        BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));
        serviceCollection.AddScoped<IRepository<UserStatistic>, UserService>();
        return serviceCollection;
    } 
}
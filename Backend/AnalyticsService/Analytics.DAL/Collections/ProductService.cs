using Analytics.DAL.Models;
using MongoDB.Driver;

namespace Analytics.DAL.Collections;

public class ProductService
{
    
    public readonly IMongoCollection<ProductService> Collection;

    public ProductService(IMongoDatabase database)
    {
        Collection = database.GetCollection<ProductService>("users");
    }
}
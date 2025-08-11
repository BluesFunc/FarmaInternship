using Analytics.DAL.Collections.Abstractions;
using Analytics.DAL.Models;
using MongoDB.Driver;

namespace Analytics.DAL.Collections;

public class ProductService(IMongoDatabase database) : RepositoryBase<ProductStatistic>(database, "products");
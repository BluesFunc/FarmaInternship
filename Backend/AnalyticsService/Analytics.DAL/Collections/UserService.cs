using Analytics.DAL.Models;
using MongoDB.Driver;

namespace Analytics.DAL.Collections;

public class UserService(IMongoDatabase database): RepositoryBase<UserStatistic>(database, "users");
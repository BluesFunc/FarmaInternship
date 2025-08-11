using System.Linq.Expressions;
using Analytics.DAL.Models;
using MongoDB.Driver;

namespace Analytics.DAL.Collections.Abstractions;

public class RepositoryBase<TModel> : IRepository<TModel> where TModel : class, IModel
{
    private IMongoCollection<TModel> _Collection { get; }


    public RepositoryBase(IMongoDatabase database, string collectionName)
    {
        _Collection = database.GetCollection<TModel>(collectionName);
    }

    public async Task<IList<TModel>> GetModelsByFilterAsync(Expression<Func<TModel, bool>>? filter = null)
    {
        filter ??= model => true;
        var res = await _Collection.FindAsync(filter);
        return await res.ToListAsync();
    }

    public async Task<TModel?> GetModelByIdAsync(Guid id)
    {
        var idFilter = Builders<TModel>.Filter.Eq("_id", id);
        var collection = await _Collection.FindAsync(idFilter);
        var res = await collection.FirstOrDefaultAsync();
        return res;
    }

    public async Task UpdateModelAsync(TModel model)
    {
        var filter = GenerateIdFilter(model);
        await _Collection.ReplaceOneAsync(filter, model);
        ;
    }

    public async Task AddModelAsync(TModel model)
    {
        await _Collection.InsertOneAsync(model);
    }

    public async Task DeleteModelAsync(TModel model)
    {
        var filter = GenerateIdFilter(model);
        await _Collection.DeleteOneAsync(filter);
    }

    private static FilterDefinition<TModel> GenerateIdFilter(TModel model)
    {
        return Builders<TModel>.Filter.Eq("_id", model.GetId());
    }
}
using System.Linq.Expressions;
using Analytics.DAL.Models;

namespace Analytics.DAL.Collections;

public interface IRepository<TModel> where TModel : IModel
{
    public Task<IList<TModel>> GetModelsByFilterAsync(Expression<Func<TModel, bool>>? filter);
    public Task<TModel?> GetModelByIdAsync(Guid id);
    public Task UpdateModelAsync(TModel model);
    public Task AddModelAsync(TModel model);
    public Task DeleteModelAsync(TModel model);
}
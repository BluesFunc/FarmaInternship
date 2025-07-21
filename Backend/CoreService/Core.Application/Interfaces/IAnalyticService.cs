using Core.Application.Dtos.Statistics;
using Core.Domain.Entities.Abstractions;

namespace Core.Application.Interfaces;

public interface IStatisticService<in TEntity > where TEntity : Entity
{
    public Task<OrderStatisticDto> CalculateStatistic(TEntity[] entities);
}
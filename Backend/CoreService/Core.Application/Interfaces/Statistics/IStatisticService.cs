using Core.Application.Dtos.Statistics;
using Core.Domain.Entities.Abstractions;

namespace Core.Application.Interfaces;

public interface IStatisticService<TMessage > where TMessage : IBrokerMessage 
{
    public TMessage CollectStatistic();
}
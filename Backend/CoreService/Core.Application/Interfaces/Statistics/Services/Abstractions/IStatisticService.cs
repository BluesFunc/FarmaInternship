using Core.Application.Dtos.Statistics.Messages;

namespace Core.Application.Interfaces.Statistics.Services.Abstractions;

public interface IStatisticService<TMessage> where TMessage : IBrokerMessage
{
    public Task<TMessage> CollectInstanceStatistic(Guid id);
}
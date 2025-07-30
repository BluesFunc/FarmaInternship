using Core.Application.Dtos.Statistics;
using Core.Application.Dtos.Statistics.Messages;

namespace Core.Application.Interfaces;

public interface IUserAnalyticService: IStatisticService<UserStatisticMessage>
{
    
}
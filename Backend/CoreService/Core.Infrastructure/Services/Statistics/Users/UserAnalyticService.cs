using Core.Application.Dtos.Statistics.Messages;
using Core.Application.Interfaces.Statistics.Services;
using Core.Infrastructure.Services.Statistics.Base;

namespace Core.Infrastructure.Services.Statistics.Users;

public class UserAnalyticService(UserStatisticService.UserStatisticServiceClient client) : IUserAnalyticService
{
    public async Task<UserStatisticMessage?> CollectInstanceStatistic(Guid id)
    {
        var request = new UserData() { UserGuid = id.ToString() };
        var response = client.GetUserStatistic(request);

        if (response is null)
        {
            return null;
        }

        var result = new UserStatisticMessage()
        {
            UserId = id,
            TotalRevenue = response.TotalRevenue,
            OrderCreated = response.OrdersCount
        };
        return result;
    }
}
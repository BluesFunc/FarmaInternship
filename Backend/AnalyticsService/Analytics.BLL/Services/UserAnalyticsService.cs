using Analytics.BLL.ProtoBase;
using Analytics.DAL.Collections.Abstractions;
using Analytics.DAL.Models;
using Grpc.Core;

namespace Analytics.BLL.Services;

public class UserAnalyticsService : UserStatisticService.UserStatisticServiceBase
{
    private IRepository<UserStatistic> _userService { get; set; }

    public UserAnalyticsService(IRepository<UserStatistic> userService)
    {
        _userService = userService;
    }

    public override async Task<UserStatisticData?> GetUserStatistic(UserData request, ServerCallContext context)
    {
        var user = await _userService.GetModelByIdAsync(Guid.Parse(request.UserGuid));
        if (user is null)
        {
            return null;
        }

        var result = new UserStatisticData()
            { OrdersCount = (ulong)user.TotalOrders, TotalRevenue = (ulong)user.TotalMoneySpend };
        return result;
    }
}
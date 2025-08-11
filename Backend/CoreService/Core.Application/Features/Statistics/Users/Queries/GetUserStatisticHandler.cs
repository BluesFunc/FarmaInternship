using Core.Application.Dtos.Statistics.Messages;
using Core.Application.Interfaces.Statistics.Services;
using Core.Application.Wrappers;
using Core.Application.Wrappers.Enums;
using MediatR;

namespace Core.Application.Features.Statistics.Users.Queries;

public class GetUserStatisticHandler : IRequestHandler<GetUserStatisticCommand, Result<UserStatisticMessage>>
{
    private IUserAnalyticService _analyticService;

    public GetUserStatisticHandler(IUserAnalyticService analyticService)
    {
        _analyticService = analyticService;
    }

    public async Task<Result<UserStatisticMessage>> Handle(GetUserStatisticCommand request,
        CancellationToken cancellationToken)
    {
        try
        {
            var result = await _analyticService.CollectInstanceStatistic(request.Id);
            return Result<UserStatisticMessage>.Successful(result);
        }
        catch (Exception ex)
        {
            return Result<UserStatisticMessage>.Failed(ErrorTypeCode.NotFound);
        }
    }
}
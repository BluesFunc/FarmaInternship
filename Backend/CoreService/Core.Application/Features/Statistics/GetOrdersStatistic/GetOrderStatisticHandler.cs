using Core.Application.Dtos.Statistics.Messages;
using Core.Application.Wrappers;
using Core.Domain.Interfaces.Repositories.Trading;
using Core.Domain.Models.QueryParams.Trading;
using MediatR;

namespace Core.Application.Features.Statistics.GetOrdersStatistic;

public class GetOrderStatisticHandler(IOrderRepository orderRepository)
    : IRequestHandler<GetOrderStatisticCommand, Result<OrderStatisticDto>>
{
    public async Task<Result<OrderStatisticDto>> Handle(GetOrderStatisticCommand request,
        CancellationToken cancellationToken)
    {
        var filter = new OrderQueryParams();
        var orders = await orderRepository.GetPaginatedAsync(filter, cancellationToken);
        var statistic = new OrderStatisticDto();
        return Result<OrderStatisticDto>.Successful(statistic);
    }
}
using Core.Application.Dtos.Statistics;
using Core.Application.Interfaces;
using Core.Application.Wrappers;
using Core.Domain.Entities.Trading;
using Core.Domain.Interfaces.Repositories.Trading;
using Core.Domain.Models.QueryParams.Trading;
using MediatR;

namespace Core.Application.Features.Statistics.GetOrdersStatistic;

public class GetOrderStatisticHandler(IOrderRepository orderRepository, IStatisticService<Order> statisticService) : IRequestHandler<GetOrderStatisticCommand, Result<OrderStatisticDto>>
{
    public async Task<Result<OrderStatisticDto>> Handle(GetOrderStatisticCommand request, CancellationToken cancellationToken)
    {
        var filter = new OrderQueryParams();
        var orders = await orderRepository.GetPaginatedAsync(filter, cancellationToken);
        var statistic = await statisticService.CalculateStatistic(orders.ToArray());
        return Result<OrderStatisticDto>.Successful(statistic);
    }
}
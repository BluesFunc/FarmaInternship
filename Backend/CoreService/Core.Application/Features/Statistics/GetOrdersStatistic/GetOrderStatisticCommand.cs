using Core.Application.Dtos.Statistics;
using Core.Application.Wrappers;
using MediatR;

namespace Core.Application.Features.Statistics.GetOrdersStatistic;

public record GetOrderStatisticCommand : IRequest<Result<OrderStatisticDto>>
{
}
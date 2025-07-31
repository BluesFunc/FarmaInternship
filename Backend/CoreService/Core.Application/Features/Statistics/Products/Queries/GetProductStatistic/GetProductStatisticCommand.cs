using Core.Application.Dtos.Statistics.Messages;
using Core.Application.Wrappers;
using MediatR;

namespace Core.Application.Features.Statistics.Products.Queries.GetProductStatistic;

public class GetProductStatisticCommand : IRequest<Result<ProductStatisticMessage>>
{
    public Guid Id { get; set; }
}
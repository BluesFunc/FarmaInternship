using Core.Application.Dtos.Statistics.Messages;
using Core.Application.Interfaces.Statistics.Services;
using Core.Application.Wrappers;
using Core.Application.Wrappers.Enums;
using MediatR;

namespace Core.Application.Features.Statistics.Products.Queries.GetProductStatistic;

public class GetProductStatisticHandler : IRequestHandler<GetProductStatisticCommand, Result<ProductStatisticMessage>>
{
    private IProductAnalyticService ProductAnalyticService { get; set; }

    public GetProductStatisticHandler(IProductAnalyticService productAnalyticService)
    {
        ProductAnalyticService = productAnalyticService;
    }

    public async Task<Result<ProductStatisticMessage>> Handle(GetProductStatisticCommand request,
        CancellationToken cancellationToken)
    {
        try
        {
            var response = await ProductAnalyticService.CollectInstanceStatistic(request.Id);
            return Result<ProductStatisticMessage>.Successful(response);
        }
        catch (Exception ex)
        {
            return Result<ProductStatisticMessage>.Failed(ErrorTypeCode.NotFound);
        }
    }
}
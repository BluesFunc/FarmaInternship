using Core.Application.Dtos.Statistics.Messages;
using Core.Application.Interfaces.Statistics.Services;
using Core.Infrastructure.Services.Statistics.Base;

namespace Core.Infrastructure.Services.Statistics.Products;

public class ProductAnalyticsService(ProductStatisticService.ProductStatisticServiceClient client)
    : IProductAnalyticService
{
    public async Task<ProductStatisticMessage> CollectInstanceStatistic(Guid id)
    {
        var request = new ProductData() { ProductGuid = id.ToString() };

        var response = client.GetProductStatistic(request);

        var result = new ProductStatisticMessage() { ProductId = id, ViewCount = response.ViewCount };
        return result;
    }
}
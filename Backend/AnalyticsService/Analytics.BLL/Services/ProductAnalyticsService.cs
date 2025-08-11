using Analytics.BLL.ProtoBase;
using Analytics.DAL.Collections.Abstractions;
using Analytics.DAL.Models;
using Grpc.Core;

namespace Analytics.BLL.Services;

public class ProductAnalyticsService : ProductStatisticService.ProductStatisticServiceBase
{
    private IRepository<ProductStatistic> _productService { get; set; }

    public ProductAnalyticsService(IRepository<ProductStatistic> userService)
    {
        _productService = userService;
    }


    public override async Task<ProductStatisticData?> GetProductStatistic(ProductData request,
        ServerCallContext context)
    {
        var user = await _productService.GetModelByIdAsync(Guid.Parse(request.ProductGuid));
        if (user is null)
        {
            return null;
        }

        var result = new ProductStatisticData() { ProductGuid = request.ProductGuid, ViewCount = user.ViewCount };
        return result;
    }
}
using Grpc.Core;
using MathNet.Numerics;
using MathNet.Numerics.Statistics;
using Analytics.BLL.ProtoBase;

namespace Analytics.BLL.Services;

public class OrderStatisticService : OrderStatistic.OrderStatisticBase
{
    public override  Task<OrderStatisticData> CalculateRevenueStatistic(IAsyncStreamReader<OrderData> requestStream,
        ServerCallContext context)
    {
        var ordersRevenue = requestStream.ReadAllAsync()
            .ToBlockingEnumerable().Select(x => x.OrderRevenue).ToArray();
        
        var variance = ArrayStatistics.Variance(ordersRevenue);
        var (mean, deviation) = ArrayStatistics.MeanStandardDeviation(ordersRevenue);
        var data = new OrderStatisticData() { Deviation = deviation, Mean = mean, Var = variance };
        return Task.FromResult(data);
    }
}
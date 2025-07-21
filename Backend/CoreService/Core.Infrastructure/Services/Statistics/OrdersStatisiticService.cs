using Core.Application.Dtos.Statistics;
using Core.Application.Interfaces;
using Core.Domain.Entities.Trading;
using Grpc.Net.Client;
using Core.Infrastructure.Services.Statistics.Base;
using Grpc.Core;

namespace Core.Infrastructure.Services.Statistics;

public class OrdersStatisticService(  OrderStatistic.OrderStatisticClient client) : 
    OrderStatistic.OrderStatisticBase, IStatisticService<Order> 
{

    public async Task<OrderStatisticDto> CalculateStatistic(Order[] entities)
    {
        var call = client.CalculateRevenueStatistic();
        foreach (var order in entities)
        {
            await call.RequestStream.WriteAsync(new OrderData() {OrderRevenue = (double)order.TotalAmount});            
        }

        await call.RequestStream.CompleteAsync();
        var data = await call.ResponseAsync;
        var result = new OrderStatisticDto() { Var = data.Var, Deviation = data.Deviation, Mean = data.Mean };
        return result;
    }
}
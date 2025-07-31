using Core.Application.Dtos.Statistics.Messages;
using Core.Application.Interfaces.Statistics.Services.Abstractions;

namespace Core.Application.Interfaces.Statistics.Services;

public interface IProductAnalyticService : IStatisticService<ProductStatisticMessage>;
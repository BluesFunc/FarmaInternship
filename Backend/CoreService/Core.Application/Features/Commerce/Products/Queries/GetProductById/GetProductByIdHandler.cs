using System.Text.Json;
using Core.Application.Configurations;
using Core.Application.Dtos.Commerce;
using Core.Application.Dtos.Statistics.Messages;
using Core.Application.Features.Abstractions;
using Core.Application.Interfaces.Statistics;
using Core.Application.Wrappers;
using Core.Application.Wrappers.Enums;
using Core.Domain.Entities.Commerce;
using Core.Domain.Interfaces.Repositories.Commerce;
using MapsterMapper;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace Core.Application.Features.Commerce.Products.Queries.GetProductById;

public class GetProductByIdHandler :
    SingleRepositoryHandlerBase<IProductRepository, Product>
    , IRequestHandler<GetProductByIdCommand, Result<ProductDto>>
{
    private IStatisticMessageProducer MessageProducer { get; set; }
    private IMemoryCache _memoryCache;
    private ILogger<GetProductByIdHandler> _logger;

    public GetProductByIdHandler(IMapper mapper, IProductRepository repository,
        IStatisticMessageProducer messageProducer, IMemoryCache memoryCache,
        ILogger<GetProductByIdHandler> logger) : base(mapper, repository)
    {
        MessageProducer = messageProducer;
        _memoryCache = memoryCache;
        _logger = logger;
    }

    public async Task<Result<ProductDto>> Handle(GetProductByIdCommand request, CancellationToken cancellationToken)
    {
        Product? entity;
        var isCached = _memoryCache.TryGetValue(request.Id, out entity);

        if (!isCached)
        {
            entity = await _repository.GetByIdAsync(request.Id, cancellationToken);

            if (entity is null)
            {
                return Result<ProductDto>.Failed(ErrorTypeCode.NotFound);
            }

            _memoryCache.Set(entity.Id, entity, DateTimeOffset.Now.Add(CachingConfigurations.ProductCacheLifetime));
        }

        var data = _mapper.Map<ProductDto>(entity);

        var message = new ProductStatisticMessage { ProductId = data.Id };
        var jsonMessage = JsonSerializer.Serialize(message, JsonSerializerOptions.Default);

        try
        {
            await MessageProducer.SendMessageAsync(StatisticBrokerConfiguration.ProductTopic, jsonMessage,
                cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.StackTrace);
        }


        return Result<ProductDto>.Successful(data);
    }
}
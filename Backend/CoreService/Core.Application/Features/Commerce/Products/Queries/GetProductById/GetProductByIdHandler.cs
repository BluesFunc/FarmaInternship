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

namespace Core.Application.Features.Commerce.Products.Queries.GetProductById;

public class GetProductByIdHandler :
    SingleRepositoryHandlerBase<IProductRepository, Product>
    , IRequestHandler<GetProductByIdCommand, Result<ProductDto>>
{
    private IStatisticMessageProducer MessageProducer { get; set; }

    public GetProductByIdHandler(IMapper mapper, IProductRepository repository,
        IStatisticMessageProducer messageProducer) : base(mapper, repository)
    {
        MessageProducer = messageProducer;
    }

    public async Task<Result<ProductDto>> Handle(GetProductByIdCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);

        if (entity is null)
        {
            return Result<ProductDto>.Failed(ErrorTypeCode.NotFound);
        }

        var data = _mapper.Map<ProductDto>(entity);

        var message = new ProductStatisticMessage() { ProductId = data.Id };
        var jsonMessage = JsonSerializer.Serialize(message, JsonSerializerOptions.Default);

        await MessageProducer.SendMessageAsync(StatisticBrokerConfiguration.ProductTopic, jsonMessage,
            cancellationToken); // Producer should serialize data

        return Result<ProductDto>.Successful(data);
    }
}
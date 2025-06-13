using Core.Application.Dtos.Trading;
using Core.Application.Features.Abstractions;
using Core.Application.Wrappers;
using Core.Application.Wrappers.Enums;
using Core.Domain.Entities.Trading;
using Core.Domain.Interfaces.Repositories.Trading;
using MapsterMapper;
using MediatR;

namespace Core.Application.Features.Trading.OrderItems.Queries.GetOrderItemById;

public class GetOrderItemByIdHandler :
    SingleRepositoryHandlerBase<IOrderItemRepository, OrderItem>,

IRequestHandler<GetOrderItemByIdCommand, Result<OrderItemDto>>
{
    public GetOrderItemByIdHandler(IMapper mapper, IOrderItemRepository repository) : base(mapper, repository)
    {
    }
    
    public async Task<Result<OrderItemDto>> Handle(GetOrderItemByIdCommand request, CancellationToken cancellationToken)
    {
        var orderItem = await _repository.GetByIdAsync(request.Id, cancellationToken);

        if (orderItem is null)
        {
            return Result<OrderItemDto>.Failed(ErrorTypeCode.NotFound);
        }

        var data = _mapper.Map<OrderItemDto>(orderItem);
        
        return Result<OrderItemDto>.Successful(data);
    }

    
}
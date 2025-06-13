using Core.Application.Dtos.Trading;
using Core.Application.Features.Abstractions;
using Core.Application.Wrappers;
using Core.Application.Wrappers.Enums;
using Core.Domain.Entities.Trading;
using Core.Domain.Interfaces.Repositories.Trading;
using MapsterMapper;
using MediatR;

namespace Core.Application.Features.Trading.Orders.Commands.UpdateOrder;

public class UpdateOrderHandler :
    SingleRepositoryHandlerBase<IOrderRepository, Order>,
    IRequestHandler<UpdateOrderCommand, Result<OrderDto>>

{
    public UpdateOrderHandler(IMapper mapper, IOrderRepository repository) : base(mapper, repository)
    {
    }

    public async Task<Result<OrderDto>> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _repository.GetByIdAsync(request.Id, cancellationToken);

        if (order == null)
        {
            return Result<OrderDto>.Failed(ErrorTypeCode.NotFound);
        }

        order.Status = request.Status;

        var data = _mapper.Map<OrderDto>(order);

        return Result<OrderDto>.Successful(data);
    }
}
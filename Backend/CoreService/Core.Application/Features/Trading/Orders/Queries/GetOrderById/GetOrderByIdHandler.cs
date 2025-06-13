using Core.Application.Dtos.Trading;
using Core.Application.Features.Abstractions;
using Core.Application.Wrappers;
using Core.Application.Wrappers.Enums;
using Core.Domain.Entities.Trading;
using Core.Domain.Interfaces.Repositories.Trading;
using MapsterMapper;
using MediatR;

namespace Core.Application.Features.Trading.Orders.Queries.GetOrderById;

public class GetOrderByIdHandler :
    SingleRepositoryHandlerBase<IOrderRepository, Order>,
    IRequestHandler<GetOrderByIdCommand, Result<OrderDto>>
{
    public GetOrderByIdHandler(IMapper mapper, IOrderRepository repository) : base(mapper, repository)
    {
    }


    public async Task<Result<OrderDto>> Handle(GetOrderByIdCommand request, CancellationToken cancellationToken)
    {
        var order = await _repository.GetByIdAsync(request.Id, cancellationToken);

        if (order is null)
        {
            return Result<OrderDto>.Failed(ErrorTypeCode.NotFound);
        }

        var data = _mapper.Map<OrderDto>(order);

        return Result<OrderDto>.Successful(data);
    }
}
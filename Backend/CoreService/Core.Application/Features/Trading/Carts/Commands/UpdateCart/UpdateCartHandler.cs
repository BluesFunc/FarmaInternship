using Core.Application.Dtos.Trading;
using Core.Application.Features.Abstractions;
using Core.Application.Wrappers;
using Core.Application.Wrappers.Enums;
using Core.Domain.Entities.Trading;
using Core.Domain.Interfaces.Repositories.Trading;
using MapsterMapper;
using MediatR;

namespace Core.Application.Features.Trading.Carts.Commands.UpdateCart;

public class UpdateCartHandler :
    SingleRepositoryHandlerBase<ICartRepository, Cart>,
    IRequestHandler<UpdateCartCommand, Result<CartDto>>
{
    public UpdateCartHandler(IMapper mapper, ICartRepository repository) : base(mapper, repository)
    {
    }

    public async Task<Result<CartDto>> Handle(UpdateCartCommand request, CancellationToken cancellationToken)
    {
        var cart = await _repository.GetByIdAsync(request.Id,cancellationToken);

        if (cart == null)
        {
            return Result<CartDto>.Failed(ErrorTypeCode.NotFound);
        }

        cart.Status = request.Status;

        var data = _mapper.Map<CartDto>(cart);

        return Result<CartDto>.Successful(data);

    }
}
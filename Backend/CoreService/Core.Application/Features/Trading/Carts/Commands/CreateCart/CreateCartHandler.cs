using Core.Application.Dtos.Trading;
using Core.Application.Features.Abstractions;
using Core.Application.Wrappers;
using Core.Application.Wrappers.Enums;
using Core.Domain.Entities.Trading;
using Core.Domain.Enums.Trading;
using Core.Domain.Interfaces.Repositories.Trading;
using MapsterMapper;
using MediatR;

namespace Core.Application.Features.Trading.Carts.Commands.CreateCart;

public class CreateCartHandler :
    SingleRepositoryHandlerBase<ICartRepository, Cart>,
    IRequestHandler<CreateCartCommand, Result<CartDto>>
{
    public CreateCartHandler(IMapper mapper, ICartRepository repository) : base(mapper, repository)
    {
    }

    public async Task<Result<CartDto>> Handle(CreateCartCommand request, CancellationToken cancellationToken)
    {
        var cart = new Cart(request.UserId)
        {
            Status = CartStatus.Active
        };

        var newEntity = await _repository.AddAsync(cart, cancellationToken);

        if (newEntity == null)
        {
            return Result<CartDto>.Failed(ErrorTypeCode.EntityConflict);
        }

        var data = _mapper.Map<CartDto>(newEntity);

        return Result<CartDto>.Successful(data);
    }
}
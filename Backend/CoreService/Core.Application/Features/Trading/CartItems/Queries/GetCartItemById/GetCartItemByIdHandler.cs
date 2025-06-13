using Core.Application.Dtos.Trading;
using Core.Application.Features.Abstractions;
using Core.Application.Wrappers;
using Core.Application.Wrappers.Enums;
using Core.Domain.Entities.Trading;
using Core.Domain.Interfaces.Repositories.Trading;
using MapsterMapper;
using MediatR;

namespace Core.Application.Features.Trading.CartItems.Queries.GetCartItemById;

public class GetCartItemByIdHandler :
    SingleRepositoryHandlerBase<ICartItemRepository, CartItem>,
    IRequestHandler<GetCartItemByIdCommand, Result<CartItemDto>>
{
    public GetCartItemByIdHandler(IMapper mapper, ICartItemRepository repository) : base(mapper, repository)
    {
    }

    public async Task<Result<CartItemDto>> Handle(GetCartItemByIdCommand request, CancellationToken cancellationToken)
    {
        var cartItem = await _repository.GetByIdAsync(request.Id, cancellationToken);

        if (cartItem == null)
        {
            return Result<CartItemDto>.Failed(ErrorTypeCode.NotFound, $"CartItem not found");
        }

        var data = _mapper.Map<CartItemDto>(cartItem);
        
        return Result<CartItemDto>.Successful(data);
    }
}
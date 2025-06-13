using Core.Application.Dtos.Trading;
using Core.Application.Features.Abstractions;
using Core.Application.Wrappers;
using Core.Application.Wrappers.Enums;
using Core.Domain.Entities.Trading;
using Core.Domain.Interfaces.Repositories.Trading;
using MapsterMapper;
using MediatR;

namespace Core.Application.Features.Trading.Carts.Queries.GetCartById;

public class GetCartByIdHandler :
    SingleRepositoryHandlerBase<ICartRepository, Cart>,
    IRequestHandler<GetCartByIdCommand, Result<CartDto>>
{
    public GetCartByIdHandler(IMapper mapper, ICartRepository repository) : base(mapper, repository)
    {
    }

    public async Task<Result<CartDto>> Handle(GetCartByIdCommand request, CancellationToken cancellationToken)
    {
        var cart = await _repository.GetByIdAsync(request.Id, cancellationToken);

        if (cart is null)
        {
            return Result<CartDto>.Failed(ErrorTypeCode.NotFound);
        }

        var data = _mapper.Map<CartDto>(cart);

        return Result<CartDto>.Successful(data);
    }
}
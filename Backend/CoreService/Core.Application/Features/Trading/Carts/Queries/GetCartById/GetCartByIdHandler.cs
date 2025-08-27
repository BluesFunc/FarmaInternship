using Core.Application.Dtos.Trading;
using Core.Application.Features.Abstractions;
using Core.Application.Requirements.ResourceAuth;
using Core.Application.Wrappers;
using Core.Application.Wrappers.Enums;
using Core.Domain.Entities.Trading;
using Core.Domain.Interfaces.Repositories.Trading;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace Core.Application.Features.Trading.Carts.Queries.GetCartById;

public class GetCartByIdHandler :
    SingleRepositoryHandlerBase<ICartRepository, Cart>,
    IRequestHandler<GetCartByIdCommand, Result<CartDto>>
{
    private HttpContext _httpContext;
    private IAuthorizationService _authorizationService;

    public GetCartByIdHandler(IMapper mapper, ICartRepository repository, IHttpContextAccessor contextAccessor,
        IAuthorizationService authorizationService) : base(mapper, repository)
    {
        _httpContext = contextAccessor.HttpContext;
        _authorizationService = authorizationService;
    }

    public async Task<Result<CartDto>> Handle(GetCartByIdCommand request, CancellationToken cancellationToken)
    {
        var cart = await _repository.GetByIdAsync(request.Id, cancellationToken);

        if (cart is null)
        {
            return Result<CartDto>.Failed(ErrorTypeCode.NotFound);
        }

        var user = _httpContext.User;

        var authorizationResult = await _authorizationService.AuthorizeAsync(user, cart, ResourcePolicies.ViewCart);

        if (!authorizationResult.Succeeded)
        {
            return Result<CartDto>.Failed(ErrorTypeCode.AuthorizationError);
        }

        var data = _mapper.Map<CartDto>(cart);

        return Result<CartDto>.Successful(data);
    }
}
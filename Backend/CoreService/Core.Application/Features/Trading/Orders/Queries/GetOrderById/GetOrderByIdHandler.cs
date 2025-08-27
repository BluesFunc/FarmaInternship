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

namespace Core.Application.Features.Trading.Orders.Queries.GetOrderById;

public class GetOrderByIdHandler :
    SingleRepositoryHandlerBase<IOrderRepository, Order>,
    IRequestHandler<GetOrderByIdCommand, Result<OrderDto>>
{
    private HttpContext _httpContext;
    private IAuthorizationService _authorizationService;

    public GetOrderByIdHandler(IMapper mapper, IOrderRepository repository, IHttpContextAccessor contextAccessor,
        IAuthorizationService authorizationService) : base(mapper, repository)
    {
        _httpContext = contextAccessor.HttpContext;
        _authorizationService = authorizationService;
    }


    public async Task<Result<OrderDto>> Handle(GetOrderByIdCommand request, CancellationToken cancellationToken)
    {
        var order = await _repository.GetByIdAsync(request.Id, cancellationToken);

        if (order is null)
        {
            return Result<OrderDto>.Failed(ErrorTypeCode.NotFound);
        }

        var user = _httpContext.User;

        var authorizationResult = await _authorizationService.AuthorizeAsync(user, order, ResourcePolicies.ViewOrder);

        if (!authorizationResult.Succeeded)
        {
            return Result<OrderDto>.Failed(ErrorTypeCode.AuthorizationError);
        }

        var data = _mapper.Map<OrderDto>(order);

        return Result<OrderDto>.Successful(data);
    }
}
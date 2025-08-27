using Core.Application.Requirements.ResourceAuth.Cart;
using Core.Domain.Entities.Trading;
using Microsoft.AspNetCore.Authorization;

namespace Core.Infrastructure.Handlers.Auth;

public class ViewCartAuthorizationHandler
    : AuthorizationHandler<ViewCartAuthorizationRequirement, Cart>
{
    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context,
        ViewCartAuthorizationRequirement requirement,
        Cart resource)
    {
        var isUserCart = context.User.Identity.Name == resource.UserId.ToString();

        if (isUserCart)
        {
            context.Succeed(requirement);
        }
    }
}
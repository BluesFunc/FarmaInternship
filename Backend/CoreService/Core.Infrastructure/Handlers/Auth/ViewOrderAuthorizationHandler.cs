using Core.Application.Requirements.ResourceAuth.Order;
using Core.Domain.Entities.Trading;
using Microsoft.AspNetCore.Authorization;

namespace Core.Infrastructure.Handlers.Auth;

public class ViewOrderAuthorizationHandler :
    AuthorizationHandler<ViewOrderAuthorizationRequirement, Order>
{
    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context,
        ViewOrderAuthorizationRequirement requirement,
        Order resource)
    {
        var isOwner = context.User.Identity.Name == resource.UserId.ToString();

        if (isOwner)
        {
            context.Succeed(requirement);
        }
    }
}
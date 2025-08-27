using Core.Application.Requirements.ResourceAuth.Product;
using Core.Domain.Entities.Commerce;
using Core.Domain.Enums;
using Microsoft.AspNetCore.Authorization;

namespace Core.Infrastructure.Handlers.Auth;

public class ProductModificationAuthorizationHandler :
    AuthorizationHandler<ProductModificationRequirement, Merchant>
{
    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context,
        ProductModificationRequirement requirement,
        Merchant resource)
    {
        var isMerchandiser = context.User.IsInRole(nameof(UserRole.Merchandiser)) &&
                             context.User.Identity.Name == resource.AdminId.ToString();

        var isAdmin = context.User.IsInRole(nameof(UserRole.Admin));

        if (isAdmin || isMerchandiser)
        {
            context.Succeed(requirement);
        }
    }
}
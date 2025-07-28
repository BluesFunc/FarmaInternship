using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace Application.Extensions;

public static class HttpContextExtension
{
    public static string? GetAuthorizationToken(this HttpContext context)
    {
        var authHeader = context.Request.Headers.Authorization
            .FirstOrDefault()?.Split(' ');
        return authHeader?.First() != "Bearer" ? null : authHeader.LastOrDefault();
    }

    public static Guid? GetUserIdFromClaims(this HttpContext context)
    {
        var userId = context.User.Claims
            .FirstOrDefault(x => x.Type == ClaimsIdentity.DefaultNameClaimType)?.Value;
        return Guid.TryParse(userId, out var userGuid) ? userGuid : null;
    }
}
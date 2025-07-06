using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace Auth.Application.Extensions;

public static class HttpContextExtension
{
    
    public static string? GetAuthorizationToken(this HttpContext context)
    {
        return context.Request.Headers.Authorization
            .FirstOrDefault()?.Split(' ').LastOrDefault();
    }

    public static Guid? GetUserIdFromClaims(this HttpContext context)
    {
        var userId = context.User
            .Claims.FirstOrDefault(x => x.Type == ClaimsIdentity.DefaultNameClaimType)?.Value;
        return Guid.TryParse(userId, out var userGuid) ? userGuid : null ;
    }
}
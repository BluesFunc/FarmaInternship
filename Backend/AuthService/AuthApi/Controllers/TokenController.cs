using Auth.Application.Interfaces.Services;
using Auth.Domain.Entities;
using Auth.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AuthApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TokenController(IJwtService service, IPasswordService passwordService) : ControllerBase
{
    [HttpGet]
    public IActionResult Token()
    {
        var claims = new Dictionary<string, object>()
        {
            { "claim", "claimData" }
        };
        var tokens = service.GenerateTokenPair(claims);

        var user = new User("Borov");
        var password = passwordService.HashPassword(user, "Sueta");
        var isSame = passwordService.VerifyHashedPassword(user, password, "Sueta") ==
                     PasswordVerificationResult.Success;
        var response = new Dictionary<string, object>()
        {
            {"access", tokens.AccessToken}
            ,{"refresh", tokens.RefreshToken}
        };
        return Ok(response);
    }
}
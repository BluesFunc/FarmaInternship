using Auth.Application.Features.Auth.Commands.RefreshToken;
using AuthApi.Controllers.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthApi.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class TokenController(ISender sender) : RestController(sender)
{
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Refresh(RefreshTokenCommand command)
        => await ExecuteMediatrCommandAsync(command);
}
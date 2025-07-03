using Auth.Application.Features.Auth.Commands.RegisterUser;
using Auth.Application.Interfaces.Services;
using AuthApi.Controllers.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AuthApi.Controllers;


public class AuthController(ISender sender) : RestController(sender)
{
    [HttpPost("[action]")]
    public async Task<IActionResult> Register(RegisterUserCommand command,
        CancellationToken cancellationToken = default) => await ExecuteMediatrCommandAsync(command, cancellationToken);
}
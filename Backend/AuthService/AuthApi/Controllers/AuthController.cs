using Application.Features.Auth.Commands.LoginUser;
using Application.Features.Auth.Commands.RegisterUser;
using Application.Features.Auth.Commands.RequestResetPassword;
using Application.Features.Auth.Commands.ResetPassword;
using AuthApi.Controllers.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AuthApi.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class AuthController(ISender sender) : RestController(sender)
{
    [HttpPost]
    public async Task<IActionResult> Register(RegisterUserCommand command,
        CancellationToken cancellationToken = default)
    {
        return await ExecuteMediatrCommandAsync(command, cancellationToken);
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginUserCommand command, CancellationToken cancellationToken = default)
    {
        return await ExecuteMediatrCommandAsync(command, cancellationToken);
    }

    [HttpPost]
    public async Task<IActionResult> RequestResetPassword(RequestResetPasswordCommand command,
        CancellationToken cancellationToken)
    {
        return await ExecuteMediatrCommandAsync(command, cancellationToken);
    }

    [HttpPost("{UserId:guid}")]
    public async Task<IActionResult> ResetPassword(ResetPasswordCommand command, CancellationToken cancellationToken)
    {
        return await ExecuteMediatrCommandAsync(command, cancellationToken);
    }
}
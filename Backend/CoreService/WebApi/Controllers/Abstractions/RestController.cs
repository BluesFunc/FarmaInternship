using Core.Application.Wrappers;
using Core.Application.Wrappers.Enums;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Abstractions;

[ApiController]
[Route("api/[controller]")]
public abstract class RestController(ISender sender) : ControllerBase

{
    protected IActionResult ToActionResult(Result result)
    {
        return result.ErrorCode switch
        {
            ErrorTypeCode.NotFound => NotFound(result.Message),
            ErrorTypeCode.EntityConflict => BadRequest(result.Message),
            ErrorTypeCode.ValidationError => UnprocessableEntity(result.Message),
            ErrorTypeCode.AuthenticationError => Unauthorized(result.Message),
            ErrorTypeCode.AuthorizationError => Forbid(JwtBearerDefaults.AuthenticationScheme),
            ErrorTypeCode.None => Ok(result),
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    protected IActionResult ToActionResult<T>(Result<T> result)
    {
        return result.ErrorCode switch
        {
            ErrorTypeCode.NotFound => NotFound(result.Message),
            ErrorTypeCode.EntityConflict => BadRequest(result.Message),
            ErrorTypeCode.ValidationError => UnprocessableEntity(result.Message),
            ErrorTypeCode.AuthenticationError => Unauthorized(result.Message),
            ErrorTypeCode.AuthorizationError => Forbid(JwtBearerDefaults.AuthenticationScheme),
            ErrorTypeCode.None => Ok(result),
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    protected async Task<IActionResult> ExecuteMediatrCommand(IRequest<Result> command)
    {
        var result = await sender.Send(command, HttpContext.RequestAborted);
        return ToActionResult(result);
    }


    protected async Task<IActionResult> ExecuteMediatrCommand<T>(IRequest<Result<T>> command)
    {
        var result = await sender.Send(command, HttpContext.RequestAborted);
        return ToActionResult(result);
    }
}
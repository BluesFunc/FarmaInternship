using Application.Wrappers;
using Application.Wrappers.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AuthApi.Controllers.Abstractions;

[ApiController]
[Route("[controller]")]
public class RestController(ISender sender) : ControllerBase
{
    private IActionResult CreateResponse(Result result)
    {
        IActionResult response = result.StatusCode switch
        {
            ErrorStatusCode.NotAnError => Ok(result),
            ErrorStatusCode.EntityConflict => BadRequest(result.Message),
            ErrorStatusCode.NotFound => NotFound(result.Message),
            ErrorStatusCode.NotAuthorized => Unauthorized(result.Message),
            ErrorStatusCode.ValidationError => UnprocessableEntity(result.Message),
            _ => throw new ArgumentOutOfRangeException()
        };
        return response;
    }

    protected async Task<IActionResult> ExecuteMediatrCommandAsync(IRequest<Result> command,
        CancellationToken cancellationToken = default)
    {
        var result = await sender.Send(command, cancellationToken);
        return CreateResponse(result);
    }

    private IActionResult CreateResponse<T>(Result<T> result)
    {
        IActionResult response = result.StatusCode switch
        {
            ErrorStatusCode.NotAnError => Ok(result),
            ErrorStatusCode.EntityConflict => BadRequest(result.Message),
            ErrorStatusCode.NotFound => NotFound(result.Message),
            ErrorStatusCode.NotAuthorized => Unauthorized(result.Message),
            ErrorStatusCode.ValidationError => UnprocessableEntity(result.Message),
            _ => throw new ArgumentOutOfRangeException()
        };
        return response;
    }

    protected async Task<IActionResult> ExecuteMediatrCommandAsync<T>(IRequest<Result<T>> command,
        CancellationToken cancellationToken = default)
    {
        var result = await sender.Send(command, cancellationToken);
        return CreateResponse(result);
    }
}
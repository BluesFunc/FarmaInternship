using Core.Application.Features.Statistics.GetOrdersStatistic;
using Core.Application.Features.Statistics.Products.Queries.GetProductStatistic;
using Core.Application.Features.Statistics.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers.Abstractions;

namespace WebApi.Controllers.Statistics;

[ApiController]
[Route("[controller]/[action]")]
public class CommerceStatistic(ISender sender) : RestController(sender)
{
    [HttpGet]
    public async Task<IActionResult> OrderStatistic([FromQuery] GetOrderStatisticCommand command)
    {
        return await ExecuteMediatrCommand(command);
    }

    [HttpGet]
    public async Task<IActionResult> UserStatistic([FromQuery] GetUserStatisticCommand command)
    {
        return await ExecuteMediatrCommand(command);
    }

    [HttpGet]
    public async Task<IActionResult> ProductStatistic([FromQuery] GetProductStatisticCommand command)
    {
        return await ExecuteMediatrCommand(command);
    }
}
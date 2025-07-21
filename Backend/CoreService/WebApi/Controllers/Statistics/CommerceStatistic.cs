using Core.Application.Features.Statistics.GetOrdersStatistic;
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
        =>  await ExecuteMediatrCommand(command);
}
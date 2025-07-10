using Core.Application.Features.Trading.OrderItems.Commands.DeleteOrderItem;
using Core.Application.Features.Trading.OrderItems.Queries.GetOrderItemById;
using Core.Application.Features.Trading.OrderItems.Queries.GetPaginatedOrderItems;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers.Abstractions;

namespace WebApi.Controllers.Trading;

[Route("api/Order/{orderId:guid}/[controller]")]
public class OrderItemController(ISender sender) : RestController(sender)
{
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var command = new GetOrderItemByIdCommand() { Id = id };
        return await ExecuteMediatrCommand(command);
    }

    [HttpDelete()]
    public async Task<IActionResult> Delete(DeleteOrderItemByIdCommand command)
    {
        return await ExecuteMediatrCommand(command);
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetPaginatedOrderItemsCommand command)
    {
        return await ExecuteMediatrCommand(command);
    }
}
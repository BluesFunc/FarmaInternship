using Core.Application.Features.Trading.Orders.Commands.CreateOrder;
using Core.Application.Features.Trading.Orders.Commands.DeleteOrderById;
using Core.Application.Features.Trading.Orders.Commands.UpdateOrder;
using Core.Application.Features.Trading.Orders.Queries.GetOrderById;
using Core.Application.Features.Trading.Orders.Queries.GetPaginatedOrders;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers.Abstractions;

namespace WebApi.Controllers.Trading;


public class OrderController(ISender sender) : RestController(sender)
{
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var command = new GetOrderByIdCommand() { Id = id };
        return await ExecuteMediatrCommand(command);
    }

    [HttpPost()]
    public async Task<IActionResult> Create(CreateOrderCommand  command)
        => await ExecuteMediatrCommand(command);
    
    [HttpDelete()]
    public async Task<IActionResult> Delete(DeleteOrderByIdCommand command)
        => await ExecuteMediatrCommand(command);
    
    [HttpPut()]
    public async Task<IActionResult> Update(UpdateOrderCommand command)
        => await ExecuteMediatrCommand(command);
    
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetPaginatedOrdersCommand command)
        => await ExecuteMediatrCommand(command);
}
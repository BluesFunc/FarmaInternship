using Core.Application.Features.Trading.CartItems.Commands.CreateCartItem;
using Core.Application.Features.Trading.CartItems.Commands.DeleteCartItemById;
using Core.Application.Features.Trading.CartItems.Commands.UpdateCartItem;
using Core.Application.Features.Trading.CartItems.Queries.GetCartItemById;
using Core.Application.Features.Trading.CartItems.Queries.GetPaginatedCartItems;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers.Abstractions;

namespace WebApi.Controllers.Trading;

[Route("api/Cart/{cartId:guid}/[controller]")]
public class CartItemController(ISender sender) : RestController(sender)
{
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var command = new GetCartItemByIdCommand() { Id = id };
        return await ExecuteMediatrCommand(command);
    }

    [HttpPost()]
    public async Task<IActionResult> Create(CreateCartItemCommand command)
    {
        return await ExecuteMediatrCommand(command);
    }

    [HttpDelete()]
    public async Task<IActionResult> Delete(DeleteCartItemByIdCommand command)
    {
        return await ExecuteMediatrCommand(command);
    }

    [HttpPut()]
    public async Task<IActionResult> Update(UpdateCartItemCommand command)
    {
        return await ExecuteMediatrCommand(command);
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetPaginatedCartItemsCommand command)
    {
        return await ExecuteMediatrCommand(command);
    }
}
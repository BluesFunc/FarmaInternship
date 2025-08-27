using Core.Application.Features.Trading.Carts.Commands.CreateCart;
using Core.Application.Features.Trading.Carts.Commands.DeleteCartById;
using Core.Application.Features.Trading.Carts.Commands.UpdateCart;
using Core.Application.Features.Trading.Carts.Queries.GetCartById;
using Core.Application.Features.Trading.Carts.Queries.GetPaginatedCarts;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers.Abstractions;

namespace WebApi.Controllers.Trading;

[Authorize]
public class CartController(ISender sender) : RestController(sender)
{
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var command = new GetCartByIdCommand { Id = id };
        return await ExecuteMediatrCommand(command);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCartCommand command)
    {
        return await ExecuteMediatrCommand(command);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(DeleteCartByIdCommand command)
    {
        return await ExecuteMediatrCommand(command);
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateCartCommand command)
    {
        return await ExecuteMediatrCommand(command);
    }


    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetPaginatedCartsCommand command)
    {
        return await ExecuteMediatrCommand(command);
    }
}
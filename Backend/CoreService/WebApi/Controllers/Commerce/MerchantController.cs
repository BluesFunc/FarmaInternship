using Core.Application.Dtos.Commerce;
using Core.Application.Features.Commerce.Medicines.Queries.GetPaginatedMedicine;
using Core.Application.Features.Commerce.Merchants.Commands.CreateMerchant;
using Core.Application.Features.Commerce.Merchants.Commands.DeleteMerchantById;
using Core.Application.Features.Commerce.Merchants.Commands.UpdateMerchant;
using Core.Application.Features.Commerce.Merchants.Queries.GetMerchantById;
using Core.Application.Features.Commerce.Merchants.Queries.GetPaginatedMedicine;
using Core.Domain.Models.QueryParams.Abstractions;
using Core.Domain.Models.QueryParams.Commerce;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers.Abstractions;

namespace WebApi.Controllers.Commerce;

public class MerchantController(ISender sender) : RestController(sender)
{
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var command = new GetMerchantByIdCommand() { Id = id };
        return await ExecuteMediatrCommand(command);
    }

    [HttpPost()]
    public async Task<IActionResult> Create(CreateMerchantCommand command)
        => await ExecuteMediatrCommand(command);
    
    [HttpDelete()]
    public async Task<IActionResult> Delete(DeleteMerchantByIdCommand command)
        => await ExecuteMediatrCommand(command);
    
    [HttpPut()]
    public async Task<IActionResult> Update(UpdateMerchantCommand command)
        => await ExecuteMediatrCommand(command);

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetPaginatedMerchantCommand command = null)
        => await ExecuteMediatrCommand(command);



}
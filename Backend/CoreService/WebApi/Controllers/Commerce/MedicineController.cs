using Core.Application.Features.Commerce.Medicines.Commands.CreateMedicine;
using Core.Application.Features.Commerce.Medicines.Commands.DeleteMedicineById;
using Core.Application.Features.Commerce.Medicines.Commands.UpdateMedicine;
using Core.Application.Features.Commerce.Medicines.Queries.GetMedicineById;
using Core.Application.Features.Commerce.Medicines.Queries.GetPaginatedMedicine;
using Core.Application.Features.Commerce.Merchants.Commands.CreateMerchant;
using Core.Application.Features.Commerce.Merchants.Commands.DeleteMerchantById;
using Core.Application.Features.Commerce.Merchants.Commands.UpdateMerchant;
using Core.Application.Features.Commerce.Merchants.Queries.GetMerchantById;
using Core.Domain.Models.QueryParams.Commerce;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers.Abstractions;

namespace WebApi.Controllers.Commerce;

public class MedicineController(ISender sender) : RestController(sender)
{
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var command = new GetMedicineByIdCommand() { Id = id };
        return await ExecuteMediatrCommand(command);
    }

    [HttpPost()]
    public async Task<IActionResult> Create(CreateMedicineCommand command)
        => await ExecuteMediatrCommand(command);

    [HttpDelete()]
    public async Task<IActionResult> Delete(DeleteMedicineByIdCommand command)
        => await ExecuteMediatrCommand(command);

    [HttpPut()]
    public async Task<IActionResult> Update(UpdateMedicineCommand command)
        => await ExecuteMediatrCommand(command);
    
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetPaginatedMedicineCommand command)
    {
        return await ExecuteMediatrCommand(command);
    }
}
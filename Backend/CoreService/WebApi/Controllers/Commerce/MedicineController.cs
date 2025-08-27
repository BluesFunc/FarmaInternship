using Core.Application.Features.Commerce.Medicines.Commands.CreateMedicine;
using Core.Application.Features.Commerce.Medicines.Commands.DeleteMedicineById;
using Core.Application.Features.Commerce.Medicines.Commands.UpdateMedicine;
using Core.Application.Features.Commerce.Medicines.Queries.GetMedicineById;
using Core.Application.Features.Commerce.Medicines.Queries.GetPaginatedMedicine;
using Core.Infrastructure.Configurations;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers.Abstractions;

namespace WebApi.Controllers.Commerce;

[Authorize(Policy = AuthorizationConfigurations.AdminOrMerchandiserPolicy)]
public class MedicineController(ISender sender) : RestController(sender)
{
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var command = new GetMedicineByIdCommand { Id = id };
        return await ExecuteMediatrCommand(command);
    }

    [Authorize(AuthorizationConfigurations.AdminPolicy)]
    [HttpPost]
    public async Task<IActionResult> Create(CreateMedicineCommand command)
    {
        return await ExecuteMediatrCommand(command);
    }

    [Authorize(AuthorizationConfigurations.AdminPolicy)]
    [HttpDelete]
    public async Task<IActionResult> Delete(DeleteMedicineByIdCommand command)
    {
        return await ExecuteMediatrCommand(command);
    }

    [Authorize(AuthorizationConfigurations.AdminPolicy)]
    [HttpPut]
    public async Task<IActionResult> Update(UpdateMedicineCommand command)
    {
        return await ExecuteMediatrCommand(command);
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetPaginatedMedicineCommand command)
    {
        return await ExecuteMediatrCommand(command);
    }
}
using Core.Application.Features.Commerce.Medicines.Commands.CreateMedicine;
using Core.Application.Features.Commerce.Medicines.Commands.DeleteMedicineById;
using Core.Application.Features.Commerce.Medicines.Commands.UpdateMedicine;
using Core.Application.Features.Commerce.Medicines.Queries.GetMedicineById;
using Core.Application.Features.Commerce.ProductCategories.Commands.Commands.CreateProductCategory;
using Core.Application.Features.Commerce.ProductCategories.Commands.Commands.DeleteProductCategory;
using Core.Application.Features.Commerce.ProductCategories.Commands.Commands.UpdateProductCategory;
using Core.Application.Features.Commerce.ProductCategories.Queries.GetPaginatedProductCategories;
using Core.Application.Features.Commerce.ProductCategories.Queries.GetProductCategoryById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers.Abstractions;

namespace WebApi.Controllers.Commerce;

public class ProductCategoryController(ISender sender) : RestController(sender)
{
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var command = new GetProductCategoryByIdCommand() { Id = id };
        return await ExecuteMediatrCommand(command);
    }

    [HttpPost()]
    public async Task<IActionResult> Create(CreateProductCategoryCommand command)
    {
        return await ExecuteMediatrCommand(command);
    }

    [HttpDelete()]
    public async Task<IActionResult> Delete(DeleteProductCategoryByIdCommand command)
    {
        return await ExecuteMediatrCommand(command);
    }

    [HttpPut()]
    public async Task<IActionResult> Update(UpdateProductCategoryCommand command)
    {
        return await ExecuteMediatrCommand(command);
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetPaginatedProductCategoryCommand command)
    {
        return await ExecuteMediatrCommand(command);
    }
}
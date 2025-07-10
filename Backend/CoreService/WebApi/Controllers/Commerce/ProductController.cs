using Core.Application.Features.Commerce.Medicines.Commands.CreateMedicine;
using Core.Application.Features.Commerce.Medicines.Commands.DeleteMedicineById;
using Core.Application.Features.Commerce.Medicines.Commands.UpdateMedicine;
using Core.Application.Features.Commerce.Medicines.Queries.GetMedicineById;
using Core.Application.Features.Commerce.ProductCategories.Commands.Commands.DeleteProductCategory;
using Core.Application.Features.Commerce.ProductCategories.Commands.Commands.UpdateProductCategory;
using Core.Application.Features.Commerce.Products.Commands.CreateProduct;
using Core.Application.Features.Commerce.Products.Commands.DeleteProductById;
using Core.Application.Features.Commerce.Products.Commands.UpdateProduct;
using Core.Application.Features.Commerce.Products.Queries.GetPaginatedProducts;
using Core.Application.Features.Commerce.Products.Queries.GetProductById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers.Abstractions;

namespace WebApi.Controllers.Commerce;

public class ProductController(ISender sender) : RestController(sender)
{
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var command = new GetProductByIdCommand() { Id = id };
        return await ExecuteMediatrCommand(command);
    }

    [HttpPost()]
    public async Task<IActionResult> Create(CreateProductCommand command)
    {
        return await ExecuteMediatrCommand(command);
    }

    [HttpDelete()]
    public async Task<IActionResult> Delete(DeleteProductByIdCommand command)
    {
        return await ExecuteMediatrCommand(command);
    }

    [HttpPut()]
    public async Task<IActionResult> Update(UpdateProductCommand command)
    {
        return await ExecuteMediatrCommand(command);
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetPaginatedProductsCommand command)
    {
        return await ExecuteMediatrCommand(command);
    }
}
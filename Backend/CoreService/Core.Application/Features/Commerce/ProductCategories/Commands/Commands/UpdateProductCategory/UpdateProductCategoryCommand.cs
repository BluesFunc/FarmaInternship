using Core.Application.Dtos.Commerce;
using Core.Application.Interfaces;
using Core.Application.Wrappers;
using MediatR;

namespace Core.Application.Features.Commerce.ProductCategories.Commands.Commands.UpdateProductCategory;

public record UpdateProductCategoryCommand : IRequest<Result<ProductCategoryDto>>, ITransactionRequest
{
    public Guid Id { get; init; }
    public required string Name { get; init; }
}
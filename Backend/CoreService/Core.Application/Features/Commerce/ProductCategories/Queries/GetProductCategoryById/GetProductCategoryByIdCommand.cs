using Core.Application.Dtos.Commerce;
using Core.Application.Features.Abstractions;
using Core.Application.Features.Abstractions.Commands.DeleteEntityByIdHandler;
using Core.Application.Wrappers;
using Core.Domain.Entities.Commerce;
using MediatR;

namespace Core.Application.Features.Commerce.ProductCategories.Queries.GetProductCategoryById;

public record GetProductCategoryByIdCommand : CommandWithEntityId<Result<ProductCategoryDto>>;
using Core.Application.Features.Abstractions;
using Core.Application.Features.Abstractions.DeleteEntityByIdHandler;
using Core.Application.Wrappers;

namespace Core.Application.Features.Commerce.ProductCategories.Commands.Commands.DeleteProductCategory;

public record DeleteProductCategoryCommand : CommandWithEntityId<Result>;
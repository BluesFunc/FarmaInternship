using Core.Application.DTOs.Commerce;
using Core.Application.Features.Abstractions;
using Core.Application.Features.Abstractions.DeleteEntityByIdHandler;
using Core.Application.Wrappers;

namespace Core.Application.Features.Commerce.Products.Qureies.GetProductById;

public record GetProductByIdCommand : CommandWithEntityId<Result<ProductDto>>;
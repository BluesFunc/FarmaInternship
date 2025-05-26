using Core.Application.DTOs.Commerce;
using Core.Application.Features.Abstractions;
using Core.Application.Features.Abstractions.DeleteEntityByIdHandler;
using Core.Application.Wrappers;
using MediatR;

namespace Core.Application.Features.Commerce.Merchants.Commands.DeleteMerchantById;

public record DeleteMerchantByIdCommand : CommandWithEntityId<Result<ProductCategoryDto>>;
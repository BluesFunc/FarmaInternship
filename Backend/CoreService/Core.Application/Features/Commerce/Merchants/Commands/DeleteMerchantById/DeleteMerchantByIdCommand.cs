using Core.Application.Features.Abstractions.Commands.DeleteEntityByIdHandler;
using Core.Application.Wrappers;

namespace Core.Application.Features.Commerce.Merchants.Commands.DeleteMerchantById;

public record DeleteMerchantByIdCommand : CommandWithEntityId<Result>;
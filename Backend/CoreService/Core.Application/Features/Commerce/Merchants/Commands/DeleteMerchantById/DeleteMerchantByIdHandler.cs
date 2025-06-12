using Core.Application.Features.Abstractions.Commands.DeleteEntityByIdHandler;
using Core.Application.Wrappers;
using Core.Domain.Entities.Commerce;
using Core.Domain.Interfaces.Repositories.Commerce;
using MapsterMapper;

namespace Core.Application.Features.Commerce.Merchants.Commands.DeleteMerchantById;

public class DeleteMerchantByIdHandler :
    DeleteEntityByIdHandlerBase<IMerchantRepository, Merchant, DeleteMerchantByIdCommand, Result>
{
    public DeleteMerchantByIdHandler(IMapper mapper, IMerchantRepository repository) : base(mapper, repository)
    {
    }
}
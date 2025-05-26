using Core.Application.DTOs.Commerce;
using Core.Application.Features.Abstractions;
using Core.Application.Features.Abstractions.DeleteEntityByIdHandler;
using Core.Application.Wrappers;
using Core.Domain.Entities.Commerce;
using Core.Domain.Interfaces.Repositories.Commerce;
using MapsterMapper;
using MediatR;

namespace Core.Application.Features.Commerce.Merchants.Commands.DeleteMerchantById;

public class DeleteMerchantByIdHandler :
    DeleteEntityByIdHandlerBase<IMerchantRepository, Merchant, Result<MedicineDto>>
{
    public DeleteMerchantByIdHandler(IMapper mapper, IMerchantRepository repository) : base(mapper, repository)
    {
    }
}
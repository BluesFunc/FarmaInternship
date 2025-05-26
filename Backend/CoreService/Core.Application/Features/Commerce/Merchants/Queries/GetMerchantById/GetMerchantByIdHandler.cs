using Core.Application.DTOs.Commerce;
using Core.Application.Features.Abstractions;
using Core.Application.Wrappers;
using Core.Application.Wrappers.Enums;
using Core.Domain.Entities.Commerce;
using Core.Domain.Interfaces.Repositories.Commerce;
using MapsterMapper;
using MediatR;

namespace Core.Application.Features.Commerce.Merchants.Queries.GetMerchantById;

public class GetMerchantByIdHandler :
    SingleRepositoryHandlerBase<IMerchantRepository, Merchant>,
    IRequestHandler<GetMerchantByIdCommand, Result<MerchantDto>>
{
    public async Task<Result<MerchantDto>> Handle(GetMerchantByIdCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null) return Result<MerchantDto>.Failed(ErrorTypeCode.NotFound, "Entity does not exist");

        var data = _mapper.Map<MerchantDto>(entity);
        return Result<MerchantDto>.Successful(data, "Successfully removed");
    }

    public GetMerchantByIdHandler(IMapper mapper, IMerchantRepository repository) : base(mapper, repository)
    {
    }
}
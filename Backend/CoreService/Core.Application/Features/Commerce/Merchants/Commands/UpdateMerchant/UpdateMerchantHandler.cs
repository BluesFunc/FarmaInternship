using Core.Application.Dtos.Commerce;
using Core.Application.Features.Abstractions;
using Core.Application.Wrappers;
using Core.Application.Wrappers.Enums;
using Core.Domain.Entities.Commerce;
using Core.Domain.Interfaces.Repositories.Commerce;
using MapsterMapper;
using MediatR;

namespace Core.Application.Features.Commerce.Merchants.Commands.UpdateMerchant;

public class UpdateMerchantHandler :
    SingleRepositoryHandlerBase<IMerchantRepository, Merchant>,
    IRequestHandler<UpdateMerchantCommand, Result<MerchantDto>>
{
    public UpdateMerchantHandler(IMapper mapper, IMerchantRepository repository) : base(mapper, repository)
    {
    }

    public async Task<Result<MerchantDto>> Handle(UpdateMerchantCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (entity is null) return Result<MerchantDto>.Failed(ErrorTypeCode.NotFound);

        entity.Name = request.Name;
        entity.Description = request.Description ?? entity.Description;

        var data = _mapper.Map<MerchantDto>(entity);

        return Result<MerchantDto>.Successful(data);
    }
}
using System.Net.Http.Headers;
using Core.Application.Dtos.Commerce;
using Core.Application.Features.Abstractions;
using Core.Application.Wrappers;
using Core.Application.Wrappers.Enums;
using Core.Domain.Entities.Commerce;
using Core.Domain.Interfaces.Repositories.Commerce;
using MapsterMapper;
using MediatR;

namespace Core.Application.Features.Commerce.Merchants.Commands.CreateMerchant;

public class CreateMerchantHandler : SingleRepositoryHandlerBase<IMerchantRepository, Merchant>,
    IRequestHandler<CreateMerchantCommand, Result<MerchantDto>>
{
    public CreateMerchantHandler(IMapper mapper, IMerchantRepository repository) : base(mapper, repository)
    {
    }

    public async Task<Result<MerchantDto>> Handle(CreateMerchantCommand request, CancellationToken cancellationToken)
    {
        var merchant = new Merchant(request.Name, request.AdminId)
        {
            Description = request.Description
        };
        
        var newEntity = await _repository.AddAsync(merchant, cancellationToken);

        if (newEntity == null)
        {
            return Result<MerchantDto>.Failed(ErrorTypeCode.EntityConflict, "Entity not created");
        }
        
        var data = _mapper.Map<MerchantDto>(newEntity);
        return Result<MerchantDto>.Successful(data);
    }
}
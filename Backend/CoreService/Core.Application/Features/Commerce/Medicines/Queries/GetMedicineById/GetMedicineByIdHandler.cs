using Core.Application.Dtos.Commerce;
using Core.Application.Features.Abstractions;
using Core.Application.Wrappers;
using Core.Application.Wrappers.Enums;
using Core.Domain.Entities.Commerce;
using Core.Domain.Interfaces.Repositories.Commerce;
using MapsterMapper;
using MediatR;

namespace Core.Application.Features.Commerce.Medicines.Queries.GetMedicineById;

public class GetMedicineByIdHandler : SingleRepositoryHandlerBase<IMedicineRepository, Medicine>,
    IRequestHandler<GetMedicineByIdCommand, Result<MedicineDto>>
{
    public GetMedicineByIdHandler(IMapper mapper, IMedicineRepository repository)
        : base(mapper, repository)
    {
    }

    public async Task<Result<MedicineDto>> Handle(GetMedicineByIdCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);

        if (entity is null)
        {
            return Result<MedicineDto>
                .Failed(ErrorTypeCode.NotFound, "Entity does not exist");
        }

        var data = _mapper.Map<MedicineDto>(entity);

        return Result<MedicineDto>.Successful(data, "Successfully removed");
    }
}
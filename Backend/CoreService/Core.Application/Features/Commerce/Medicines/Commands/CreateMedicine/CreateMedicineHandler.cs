using Core.Application.Dtos.Commerce;
using Core.Application.Features.Abstractions;
using Core.Application.Wrappers;
using Core.Application.Wrappers.Enums;
using Core.Domain.Entities.Commerce;
using Core.Domain.Interfaces.Repositories.Commerce;
using MapsterMapper;
using MediatR;

namespace Core.Application.Features.Commerce.Medicines.Commands.CreateMedicine;

public class CreateMedicineHandler : SingleRepositoryHandlerBase<IMedicineRepository, Medicine>,
    IRequestHandler<CreateMedicineCommand, Result<MedicineDto>>
{
    public CreateMedicineHandler(IMapper mapper, IMedicineRepository repository)
        : base(mapper, repository)
    {
    }

    public async Task<Result<MedicineDto>> Handle(CreateMedicineCommand request,
        CancellationToken cancellationToken = default)
    {
        var newEntity = new Medicine()
        {
            Name = request.Name,
            Type = request.Type,
            MeasureUnit = request.MeasureUnit,
            Volume = request.Volume,
            ManufacturerOrigin = request.ManufacturerOrigin,
            ManufacturerName = request.ManufacturerName
        };

        var result = await _repository.AddAsync(newEntity, cancellationToken);

        if (result is null)
        {
            return Result<MedicineDto>
                .Failed(ErrorTypeCode.EntityConflict, "Can not create entity");
        }

        var responseData = _mapper.Map<MedicineDto>(result);

        return Result<MedicineDto>.Successful(responseData);
    }
}
using Core.Application.Dtos.Commerce;
using Core.Application.Features.Abstractions;
using Core.Application.Wrappers;
using Core.Application.Wrappers.Enums;
using Core.Domain.Entities.Commerce;
using Core.Domain.Interfaces.Repositories.Commerce;
using MapsterMapper;
using MediatR;

namespace Core.Application.Features.Commerce.Medicines.Commands.UpdateMedicine;

public class UpdateMedicineHandler : SingleRepositoryHandlerBase<IMedicineRepository, Medicine>,
    IRequestHandler<UpdateMedicineCommand, Result<MedicineDto>>
{
    public UpdateMedicineHandler(IMapper mapper, IMedicineRepository repository) : base(mapper, repository)
    {
    }

    public async Task<Result<MedicineDto>> Handle(UpdateMedicineCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);

        if (entity == null)
        {
            return Result<MedicineDto>.Failed(ErrorTypeCode.NotFound);
        }
            
        entity.Name = request.Name;
        entity.Type = request.Type;
        entity.MeasureUnit = request.MeasureUnit;
        entity.Volume = request.Volume;
        entity.ManufacturerName = request.ManufacturerName;
        entity.ManufacturerOrigin = request.ManufacturerOrigin;
        
        var updatedEntity = _repository.Update(entity);
        
        var data = _mapper.Map<MedicineDto>(updatedEntity);
        
        return Result<MedicineDto>.Successful(data);
    }
}
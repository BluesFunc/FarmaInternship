using Core.Application.DTOs.Commerce;
using Core.Application.Features.Abstractions;
using Core.Application.Features.Abstractions.DeleteEntityByIdHandler;
using Core.Application.Wrappers;
using Core.Application.Wrappers.Enums;
using Core.Domain.Entities.Commerce;
using Core.Domain.Interfaces.Repositories.Commerce;
using MapsterMapper;
using MediatR;

namespace Core.Application.Features.Commerce.Medicines.Commands.DeleteMedicineById;

public class DeleteMedicineByIdHandler :
    DeleteEntityByIdHandlerBase<IMedicineRepository, Medicine, Result<MedicineDto>>

{
    public DeleteMedicineByIdHandler(IMapper mapper, IMedicineRepository repository) : base(mapper, repository)
    {
    }
}
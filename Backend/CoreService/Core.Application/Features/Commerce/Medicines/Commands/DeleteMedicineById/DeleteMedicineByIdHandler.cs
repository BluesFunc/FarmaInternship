using Core.Application.Features.Abstractions.Commands.DeleteEntityByIdHandler;
using Core.Application.Wrappers;
using Core.Domain.Entities.Commerce;
using Core.Domain.Interfaces.Repositories.Commerce;
using MapsterMapper;

namespace Core.Application.Features.Commerce.Medicines.Commands.DeleteMedicineById;

public class DeleteMedicineByIdHandler :
    DeleteEntityByIdHandlerBase<IMedicineRepository, Medicine, DeleteMedicineByIdCommand, Result>

{
    public DeleteMedicineByIdHandler(IMapper mapper, IMedicineRepository repository) : base(mapper, repository)
    {
    }
}
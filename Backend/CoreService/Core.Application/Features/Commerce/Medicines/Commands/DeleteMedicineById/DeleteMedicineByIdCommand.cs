using Core.Application.Features.Abstractions.Commands.DeleteEntityByIdHandler;
using Core.Application.Wrappers;

namespace Core.Application.Features.Commerce.Medicines.Commands.DeleteMedicineById;

public record DeleteMedicineByIdCommand : CommandWithEntityId<Result>
{
}
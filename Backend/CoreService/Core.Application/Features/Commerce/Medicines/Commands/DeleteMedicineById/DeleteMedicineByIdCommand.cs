using Core.Application.Features.Abstractions.DeleteEntityByIdHandler;
using Core.Application.Wrappers;
using MediatR;

namespace Core.Application.Features.Commerce.Medicines.Commands.DeleteMedicineById;

public record DeleteMedicineByIdCommand : CommandWithEntityId<Result>
{
}
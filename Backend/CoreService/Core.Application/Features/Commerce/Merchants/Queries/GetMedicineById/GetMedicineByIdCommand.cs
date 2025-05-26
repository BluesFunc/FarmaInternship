using Core.Application.DTOs.Commerce;
using Core.Application.Features.Abstractions.DeleteEntityByIdHandler;
using Core.Application.Wrappers;
using MediatR;

namespace Core.Application.Features.Commerce.Merchants.Queries.GetMedicineById;

public record GetMedicineByIdCommand : CommandWithEntityId<Result<MedicineDto>>
{
}
using Core.Application.DTOs.Commerce;
using Core.Application.Wrappers;
using MediatR;

namespace Core.Application.Features.Commerce.Medicines.Queries.GetMedicineById;

public record GetMedicineByIdCommand : IRequest<Result<MedicineDto>>
{
    public Guid Id { get; init; }
}
using Core.Application.Dtos.Commerce;
using Core.Application.Features.Abstractions.Queries.GetPaginatedEntities;

namespace Core.Application.Features.Commerce.Medicines.Queries.GetPaginatedMedicine;

public record GetPaginatedMedicineCommand : GetPaginatedEntitiesCommand<MedicineDto>
{
}
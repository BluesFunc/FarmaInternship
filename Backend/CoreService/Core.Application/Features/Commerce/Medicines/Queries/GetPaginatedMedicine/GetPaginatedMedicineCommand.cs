using Core.Application.Dtos.Commerce;
using Core.Application.Features.Abstractions.Queries.GetPaginatedEntities;
using Core.Domain.Models.QueryParams.Commerce;

namespace Core.Application.Features.Commerce.Medicines.Queries.GetPaginatedMedicine;

public record GetPaginatedMedicineCommand : GetPaginatedEntitiesCommand<MedicineDto, MedicineQueryParams>;
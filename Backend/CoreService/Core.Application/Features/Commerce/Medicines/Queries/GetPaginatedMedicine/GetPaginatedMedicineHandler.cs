using Core.Application.Dtos.Commerce;
using Core.Application.Features.Abstractions.Queries.GetPaginatedEntities;
using Core.Domain.Entities.Commerce;
using Core.Domain.Interfaces.Repositories.Commerce;
using Core.Domain.Models.QueryParams.Commerce;
using MapsterMapper;

namespace Core.Application.Features.Commerce.Medicines.Queries.GetPaginatedMedicine;

public class GetPaginatedMedicineHandler :
    GetPaginatedEntitiesHandlerBase<IMedicineRepository,
        Medicine, GetPaginatedMedicineCommand,
        MedicineDto, MedicineQueryParams>
{
    public GetPaginatedMedicineHandler(IMapper mapper, IMedicineRepository repository) : base(mapper, repository)
    {
    }
}
using Core.Domain.Entities.Commerce;
using Core.Domain.Models.QueryParams.Commerce;

namespace Core.Domain.Interfaces.Repositories.Commerce;

public interface IMedicineRepository : IFilteredRepository<MedicineQueryParams, Medicine>;
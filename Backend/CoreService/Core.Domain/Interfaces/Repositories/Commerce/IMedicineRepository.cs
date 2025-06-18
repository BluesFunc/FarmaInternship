using Core.Domain.Entities.Abstractions;
using Core.Domain.Entities.Commerce;

namespace Core.Domain.Interfaces.Repositories.Commerce;

public interface IMedicineRepository : IFilteredRepository<Medicine>;
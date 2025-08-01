using Core.Application.Dtos.Commerce;
using Core.Domain.Entities.Commerce;
using Core.Domain.Enums.Commerce;
using Core.Domain.Interfaces.Repositories.Commerce;
using Core.Domain.Models.QueryParams.Commerce;
using MapsterMapper;
using Moq;

namespace Core.Tests.api_v1.Unit.Features.Medicines;

public class MedicineFeaturesFixture
{
    public readonly Mock<IMapper> Mapper;
    public readonly Mock<IMedicineRepository> Repository;
    public readonly Medicine MedicineInstance;
    public readonly MedicineDto MedicineDtoInstance;

    public MedicineFeaturesFixture()
    {
        Mapper = new Mock<IMapper>(MockBehavior.Loose);
        Repository = new Mock<IMedicineRepository>();
        MedicineInstance = new Medicine()
        {
            ManufacturerName = "BelMed", ManufacturerOrigin = "Belarus", MeasureUnit = MedicineMeasureUnit.MilliLiter,
            Volume = 1000, Name = "Antihrip", Type = MedicineType.Liquid
        };
        MedicineDtoInstance = new MedicineDto() {
            ManufacturerName = "BelMed", ManufacturerOrigin = "Belarus", MeasureUnit = MedicineMeasureUnit.MilliLiter,
            Volume = 1000, Name = "Antihrip", Type = MedicineType.Liquid
        };

        Repository.Setup(x =>
                x.AddAsync(It.IsAny<Medicine>(), default))
            .ReturnsAsync(MedicineInstance);
        Repository.Setup(x => x.Delete(It.IsAny<Medicine>())).Returns(true);
        Repository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>(), default))
            .ReturnsAsync(MedicineInstance);
        Repository.Setup(x => x.GetPaginatedAsync(It.IsAny<MedicineQueryParams>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync([MedicineInstance]);

        Mapper.Setup(x => x.Map<IReadOnlyList<MedicineDto>>(It.IsAny<IReadOnlyList<Medicine>>()))
            .Returns([MedicineDtoInstance]);
        
        Mapper.Setup(x => x.Map<MedicineDto>(It.IsAny<Medicine>()))
            .Returns(MedicineDtoInstance);
    }
}
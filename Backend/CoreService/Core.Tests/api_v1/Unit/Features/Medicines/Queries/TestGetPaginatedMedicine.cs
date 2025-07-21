using Core.Application.Features.Commerce.Medicines.Queries.GetPaginatedMedicine;
using Core.Domain.Entities.Commerce;
using Core.Domain.Models.QueryParams.Commerce;
using FluentAssertions;
using Moq;

namespace Core.Tests.api_v1.Unit.Features.Medicines.Queries;

[Collection("Medicine fixtures")]
public class TestGetPaginatedMedicine
{
    private readonly MedicineFeaturesFixture _fixture;

    public TestGetPaginatedMedicine(MedicineFeaturesFixture fixture)
    {
        _fixture = fixture;
        
    }

    [Fact]
    public async void Handle_GetPaginatedList_ContainsEntity()
    {
        var filter = new MedicineQueryParams();
        var command = new GetPaginatedMedicineCommand() { Filter = filter };

       
        var handler = new GetPaginatedMedicineHandler(_fixture.Mapper.Object, _fixture.Repository.Object);

        var result = await handler.Handle(command);

        result.Data.TotalElements.Should().BePositive();

    }
}
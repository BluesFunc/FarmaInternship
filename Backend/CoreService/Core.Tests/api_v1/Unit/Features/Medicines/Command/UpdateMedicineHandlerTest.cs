using Core.Application.Features.Commerce.Medicines.Commands.UpdateMedicine;
using FluentAssertions;

namespace Core.Tests.api_v1.Unit.Features.Medicines.Command;

[Collection("Medicine fixtures")]
public class UpdateMedicineHandlerTest
{
    private readonly MedicineFeaturesFixture _fixture;

    public UpdateMedicineHandlerTest(MedicineFeaturesFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task Handle_UpdateInstance_AssumeSucceed()
    {
        //Arrange
        var instance = _fixture.MedicineInstance;
        var command = new UpdateMedicineCommand()
        {
            Id = new Guid(),
            ManufacturerName = instance.ManufacturerName,
            ManufacturerOrigin = instance.ManufacturerOrigin,
            MeasureUnit = instance.MeasureUnit,
            Name = instance.Name,
            Volume = instance.Volume,
            Type = instance.Type
        };

        //Act
        var handler = new UpdateMedicineHandler(_fixture.Mapper.Object, _fixture.Repository.Object);
        var result = await handler.Handle(command, default);

        
        //Assert
        result.IsSucceed.Should().BeTrue();
        _fixture.Repository.Verify();
    }
}
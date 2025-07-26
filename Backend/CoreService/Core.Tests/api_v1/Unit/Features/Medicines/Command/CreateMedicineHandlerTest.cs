using System.Runtime.CompilerServices;
using Core.Application.Features.Commerce.Medicines.Commands.CreateMedicine;
using Core.Domain.Entities.Commerce;
using Core.Domain.Enums.Commerce;
using FluentAssertions;
using Moq;

namespace Core.Tests.api_v1.Unit.Features.Medicines.Command;

[Collection("Medicine fixtures")]
public class CreateMedicineHandlerTest
{
    private readonly MedicineFeaturesFixture _fixture;

    public CreateMedicineHandlerTest(MedicineFeaturesFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task Handle_CreateNewInstance_AssumeSucceed() // Replace void with Task
    {
        
        //Arrange
        var instance = _fixture.MedicineInstance;
        var command = new CreateMedicineCommand()
        {
            ManufacturerName = instance.ManufacturerName, ManufacturerOrigin = instance.ManufacturerOrigin,
            MeasureUnit = instance.MeasureUnit,
            Volume = instance.Volume, Name = instance.Name, Type = instance.Type
        };
        var handler = new CreateMedicineHandler(_fixture.Mapper.Object, _fixture.Repository.Object); // rename handlers with SAT(system under test)
        
        
        //Act
        var result = await handler.Handle(command);

            
        //Assert
        result.IsSucceed.Should().BeTrue();
        _fixture.Repository.Verify(
            x => x.AddAsync(
                It.Is<Medicine>(med => med.Name == command.Name), It.IsAny<CancellationToken>()),
            Times.Once
        );
    }
}
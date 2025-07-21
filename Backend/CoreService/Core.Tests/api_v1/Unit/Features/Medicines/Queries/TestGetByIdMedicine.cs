using System.Runtime.CompilerServices;
using Core.Application.Dtos.Commerce;
using Core.Application.Features.Commerce.Medicines.Queries.GetMedicineById;
using Core.Domain.Entities.Commerce;
using Core.Domain.Interfaces.Repositories.Commerce;
using FluentAssertions;
using Moq;

namespace Core.Tests.api_v1.Unit.Features.Medicines.Queries;

[Collection("Medicine fixtures")]
public class TestGetByIdMedicine
{
    private readonly MedicineFeaturesFixture _fixture;

    public TestGetByIdMedicine(MedicineFeaturesFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async void Handle_GetEntityById_AssumeSucceed()
    {
        var command = new GetMedicineByIdCommand() { Id = new Guid() };
        var handler = new GetMedicineByIdHandler(_fixture.Mapper.Object, _fixture.Repository.Object);

        var result = await handler.Handle(command);

        result.IsSucceed.Should().BeTrue();
        _fixture.Mapper.Verify(x =>
            x.Map<MedicineDto>(
                It.Is<Medicine>(med => med.Name == _fixture.MedicineInstance.Name)), Times.Once
            );
       
    }

    [Fact]
    public async void Handle_GetEntityByIdThatDoesntExist_ExpectResultFailed()
    {
        var command = new GetMedicineByIdCommand() { Id = new Guid() };
        var repository = new Mock<IMedicineRepository>(MockBehavior.Strict);
        
        
        repository.Setup(x => x.GetByIdAsync(command.Id, default)).ReturnsAsync((Medicine?)null);
        var handler = new GetMedicineByIdHandler(_fixture.Mapper.Object, repository.Object);
        var result = await handler.Handle(command);
        

        result.IsFailed.Should().BeTrue();
        _fixture.Mapper.Verify(x => x.Map<MedicineDto>(It.IsAny<Medicine>()), Times.Never);
    }
}
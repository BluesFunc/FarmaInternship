using Core.Application.Features.Commerce.Medicines.Commands.DeleteMedicineById;
using Core.Application.Wrappers.Enums;
using Core.Domain.Entities.Abstractions;
using Core.Domain.Entities.Commerce;
using FluentAssertions;
using Moq;

namespace Core.Tests.api_v1.Unit.Features.Medicines.Command;

[Collection("Medicine fixtures")]
public class DeleteMedicineByIdHandlerTest
{
    private readonly MedicineFeaturesFixture _fixture;

    public DeleteMedicineByIdHandlerTest(MedicineFeaturesFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async void Handle_DeleteInstance_AssumeSucceed()
    {
        var command = new DeleteMedicineByIdCommand() { Id = new Guid() };
        
        var handler = new DeleteMedicineByIdHandler(_fixture.Mapper.Object, _fixture.Repository.Object);


        var result = await handler.Handle(command);

        result.IsSucceed.Should().BeTrue();
        result.ErrorCode.Should().Be(ErrorTypeCode.None);
        _fixture.Repository.Verify(x => x.Delete(It.Is<Medicine>(med => med.Id == command.Id)));
    }
}
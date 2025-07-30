using Auth.Infrastructure.Services;
using AutoFixture;
using AutoFixture.Xunit2;
using Domain.Entities;
using Moq;

namespace Auth.Tests.ApiV1.Unit.Services.EmailService;

[Collection("PasswordService")]
public class PasswordServiceTests
{
    private PasswordServiceFixture _fixture { get; set; }
    private Fixture _dataBakery { get; set; }

    public PasswordServiceTests(PasswordServiceFixture fixture)
    {
        _fixture = fixture;
        _dataBakery = new Fixture();
    }


    [Fact]
    public async Task Verify_That_PasswordHasher_HashPassword_Executed_Once()
    {
        // Arrange
        var service = new PasswordService(_fixture.PasswordHasher.Object);


        // Act
        service.HashPassword(It.IsAny<User>(), It.IsAny<string>());

        //Assert
        _fixture.PasswordHasher.Verify(x => x.HashPassword(It.IsAny<User>(), It.IsAny<string>()), Times.Once);
    }

    [Fact]
    public async Task Verify_That_PasswordHasher_VerifyPassword_Executed_Once()
    {
        // Arrange
        var service = new PasswordService(_fixture.PasswordHasher.Object);


        // Act
        service.VerifyHashedPassword(It.IsAny<User>(), It.IsAny<string>(), It.IsAny<string>());

        //Assert
        _fixture.PasswordHasher.Verify(
            x => x.VerifyHashedPassword(It.IsAny<User>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once);
    }
}
using Auth.Infrastructure.Services;
using AutoFixture;
using AutoFixture.Xunit2;
using Domain.Entities;
using FluentAssertions;

namespace Auth.Tests.ApiV1.Unit.Services.JwtServices;

[Collection("JwtService")]
public class JwtServiceTests
{
    private Fixture _dataBakery { get; set; }
    private JwtServiceFixture _fixture { get; set; }

    public JwtServiceTests( JwtServiceFixture fixture)
    {
        _dataBakery = new Fixture();
        _fixture = fixture;
    }

    [Theory, AutoData]
    public void Create_TokenPair_And_Check_Their_Inequality(User user)
    {
        //Arrange
        var service = new JwtService(_fixture.Handler);
        
        //Act
        var tokenPair = service.GenerateTokenPair(user);
        
        //Assert
        tokenPair.RefreshToken.Should().NotBe(tokenPair.AccessToken);
    }
}
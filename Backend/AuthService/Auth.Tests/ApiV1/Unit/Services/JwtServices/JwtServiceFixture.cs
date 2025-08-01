using System.IdentityModel.Tokens.Jwt;

namespace Auth.Tests.ApiV1.Unit.Services.JwtServices;

public class JwtServiceFixture
{
    public JwtSecurityTokenHandler Handler { get; set; }

    public JwtServiceFixture()
    {
        Handler = new JwtSecurityTokenHandler();
    }
}

[CollectionDefinition("JwtService")]
public class JwtServiceFixtureCollection : ICollectionFixture<JwtServiceFixture>;
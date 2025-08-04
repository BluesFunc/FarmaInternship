using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Moq;

namespace Auth.Tests.ApiV1.Unit.Services.PasswordService;

public class PasswordServiceFixture
{
    public Mock<IPasswordHasher<User>> PasswordHasher { get; init; }

    public PasswordServiceFixture()
    {
        PasswordHasher = new Mock<IPasswordHasher<User>>();
    }
}

[CollectionDefinition("PasswordService")]
public class PasswordFixtureCollection : ICollectionFixture<PasswordServiceFixture>;
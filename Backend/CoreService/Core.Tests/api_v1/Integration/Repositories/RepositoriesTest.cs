using AutoFixture;
using AutoFixture.Xunit2;
using Core.Domain.Entities.Commerce;
using Core.Domain.Interfaces.Repositories.Commerce;
using Core.Infrastructure.Handlers.Repositories.Commerce;
using Core.Tests.api_v1.Integration.Repositories.Contexts;
using FluentAssertions;

namespace Core.Tests.api_v1.Integration.Repositories;

[Collection("Repositories")]
public class RepositoriesTest
{
    private IMedicineRepository _medicineRepository;
    private TestingDatabaseContext _testingContext;
    private DatabaseFixture _fixture;
    private Fixture _dataBakery;
    
    public RepositoriesTest(DatabaseFixture fixture)
    {
        _fixture = fixture;
        _testingContext = new TestingDatabaseContext(_fixture.DbOptions);
        _medicineRepository = new MedicineRepository(_testingContext);
        _dataBakery = new Fixture();
    }

    [Theory, AutoData]
    public async Task AddAsync_CreateNewInstance_EnsureCreatedAtDatabase(Medicine medicine)
    {
        // Assert
        medicine.CreatedAt = DateTime.UtcNow;
        medicine.ModifiedAt = DateTime.UtcNow;
        
        //Act
        var entry = await _medicineRepository.AddAsync(medicine);
        await _testingContext.SaveChangesAsync();

        var isCreated = await _medicineRepository.IsExistAsync(x => x.Id == medicine.Id);

        // Assert
        isCreated.Should().BeTrue();
    }
    
    [Theory, AutoData]
    public async Task Delete_CreateNewInstance_ThenDeleteThat_EnsureDeletedAtDatabase(Medicine medicine)
    {
        
        // Arrange
        medicine.CreatedAt = DateTime.UtcNow;
        medicine.ModifiedAt = DateTime.UtcNow;
        var entry = await _medicineRepository.AddAsync(medicine);
        await _testingContext.SaveChangesAsync();
        
        // Act
        var result = _medicineRepository.Delete(entry);
        await _testingContext.SaveChangesAsync();
        var isExist = await _medicineRepository.IsExistAsync(x => x.Id == medicine.Id);

        // Assert
        result.Should().BeTrue();
        isExist.Should().BeFalse();
    }
    
    [Theory, AutoData]
    public async Task Update_CreateNewInstance_ThenUpdateData_EnsureEntryUpdatedAtDatabase(Medicine originMedicine)
    {
        // Arrange
        originMedicine.CreatedAt = DateTime.UtcNow;
        originMedicine.ModifiedAt = DateTime.UtcNow;
        
        var entry = await _medicineRepository.AddAsync(originMedicine);
        await _testingContext.SaveChangesAsync();

        // Act
        var originName = entry.Name;
        entry.Name = _dataBakery.Create<string>();
        var result = _medicineRepository.Update(entry);
        await _testingContext.SaveChangesAsync();
        
        // Assert
        result.Name.Should().NotBe(originName);
    }
    
}
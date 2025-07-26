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
    public async void AddAsync_CreateNewInstance_EnsureCreatedAtDatabase(Medicine medicine)
    {
        medicine.CreatedAt = DateTime.UtcNow;
        medicine.ModifiedAt = DateTime.UtcNow;
        var entry = await _medicineRepository.AddAsync(medicine);
        
        entry.Should().NotBeNull(); // Invalid test structure

        await _testingContext.SaveChangesAsync();

        var isCreated = await _medicineRepository.IsExistAsync(x => x.Id == medicine.Id);

        isCreated.Should().BeTrue();
    }
    
    [Theory, AutoData]
    public async void Delete_CreateNewInstance_ThenDeleteThat_EnsureDeletedAtDatabase(Medicine medicine)
    {
        medicine.CreatedAt = DateTime.UtcNow;
        medicine.ModifiedAt = DateTime.UtcNow;
        var entry = await _medicineRepository.AddAsync(medicine);
        
        await _testingContext.SaveChangesAsync();

        var isCreated = await _medicineRepository.IsExistAsync(x => x.Id == medicine.Id);
        
        isCreated.Should().BeTrue();
        
        var result = _medicineRepository.Delete(entry);
        
        result.Should().BeTrue();

        await _testingContext.SaveChangesAsync();
        
        var isExist = await _medicineRepository.IsExistAsync(x => x.Id == medicine.Id);

        isExist.Should().BeFalse();
    }
    
    [Theory, AutoData]
    public async void Update_CreateNewInstance_ThenUpdateData_EnsureEntryUpdatedAtDatabase(Medicine originMedicine)
    {
        originMedicine.CreatedAt = DateTime.UtcNow;
        originMedicine.ModifiedAt = DateTime.UtcNow;
        
        var entry = await _medicineRepository.AddAsync(originMedicine);
        entry.Should().NotBeNull();
        await _testingContext.SaveChangesAsync();

        var originName = entry.Name;
        entry.Name = _dataBakery.Create<string>();
        
        var result = _medicineRepository.Update(entry);
        
        await _testingContext.SaveChangesAsync();
        
        result.Name.Should().NotBe(originName);
    }
    
}
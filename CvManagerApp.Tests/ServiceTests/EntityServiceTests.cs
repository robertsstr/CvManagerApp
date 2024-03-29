using CvManagerApp.Services;
using CvManagerApp.Tests.Models;
using Microsoft.EntityFrameworkCore;

namespace CvManagerApp.Tests.ServiceTests;

[TestFixture]
public class EntityServiceTests
{
    private TestDbContext _context;
    private EntityService<TestEntity> _service;

    [SetUp]
    public void Setup()
    {
        var options = new DbContextOptionsBuilder<TestDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        _context = new TestDbContext(options);
        _service = new EntityService<TestEntity>(_context);
    }

    [Test]
    public async Task Create_ShouldAddEntityToDatabase()
    {
        // Arrange
        var entity = new TestEntity { Name = "Test" };

        // Act
        await _service.Create(entity);

        // Assert
        var createdEntity = _context.TestEntities.Find(entity.Id);
        Assert.IsNotNull(createdEntity);
        Assert.That(createdEntity.Name, Is.EqualTo(entity.Name));
    }

    [Test]
    public async Task GetAll_ShouldReturnAllEntities()
    {
        // Arrange
        var entity1 = new TestEntity { Name = "Entity1" };
        var entity2 = new TestEntity { Name = "Entity2" };
        await _service.Create(entity1);
        await _service.Create(entity2);

        // Act
        var entities = await _service.GetAll();

        // Assert
        Assert.That(entities.Count, Is.EqualTo(2));
        Assert.IsTrue(entities.Any(e => e.Name == "Entity1"));
        Assert.IsTrue(entities.Any(e => e.Name == "Entity2"));
    }

    [Test]
    public async Task GetById_ShouldReturnEntityById()
    {
        // Arrange
        var entity = new TestEntity { Name = "Test" };
        await _service.Create(entity);

        // Act
        var receivedEntity = await _service.GetById(entity.Id);

        // Assert
        Assert.IsNotNull(receivedEntity);
        Assert.That(receivedEntity.Name, Is.EqualTo(entity.Name));
    }

    [Test]
    public async Task Update_ShouldUpdateEntity()
    {
        // Arrange
        var entity = new TestEntity { Name = "OldName" };
        await _service.Create(entity);
        entity.Name = "NewName";

        // Act
        await _service.Update(entity);

        // Assert
        var updatedEntity = await _service.GetById(entity.Id);
        Assert.IsNotNull(updatedEntity);
        Assert.AreEqual("NewName", updatedEntity.Name);
    }

    [TearDown]
    public void TearDown()
    {
        _context.Database.EnsureDeleted();
        _context.Dispose();
    }
}
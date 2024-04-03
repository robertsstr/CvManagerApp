using CvManagerApp.Core.Models;
using CvManagerApp.Services;
using Microsoft.EntityFrameworkCore;

namespace CvManagerApp.Tests.ServiceTests;

[TestFixture]
public class CvServiceTests
{
    private TestDbContext _context;
    private CvService _service;
    private Cv _cv;

    [SetUp]
    public void Setup()
    {
        var options = new DbContextOptionsBuilder<TestDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        _context = new TestDbContext(options);
        _service = new CvService(_context);
        _cv = new Cv()
        {
            FirstName = "Test",
            LastName = "User",
            PhoneNumber = "27777777",
            Email = "testuser@test.com",
            DateOfBirth = "2024-01-01",
            Educations = new List<Education>
            {
                new Education { EducationalEstablishment = "Test Unitversity" },
            },
            WorkExperiences = new List<WorkExperience>
            {
                new WorkExperience { Company = "Your advertisement here" },
            },
            SkillsAchievements = new List<SkillAchievement>
            {
                new SkillAchievement { SkillOrAchievement = "C#"},
            }
        };
    }

    [Test]
    public async Task CvExists_ValidNonDuplicate_ReturnsFalse()
    {
        //Arrange
        var secondCv = new Cv()
        {
            FirstName = "Bob",
            LastName = "Bobert",
            PhoneNumber = "22222222"
        };
        await _service.Create(_cv);

        //Act
        bool result = await _service.CvExists(secondCv);

        //Assert
        Assert.IsFalse(result);
    }

    [Test]
    public async Task CvExists_InvalidDuplicate_ReturnsTrue()
    {
        //Arrange
        var secondCv = new Cv()
        {
            FirstName = "Test",
            LastName = "User",
            PhoneNumber = "27777777"
        };
        await _service.Create(_cv);

        //Act
        bool result = await _service.CvExists(secondCv);

        //Assert
        Assert.IsTrue(result);
    }

    [Test]
    public async Task GetFullCv_ValidCv_ReturnsFullCvWithRelatedEntities()
    {
        // Arrange
        await _service.Create(_cv);

        // Act
        var receivedCv = await _service.GetFullCv(_cv.Id);

        // Assert
        Assert.IsNotNull(receivedCv);
        Assert.That(receivedCv.Id, Is.EqualTo(_cv.Id));
        Assert.That(receivedCv.FirstName, Is.EqualTo(_cv.FirstName));
        Assert.IsNotNull(receivedCv.Educations);
        Assert.IsNotNull(receivedCv.WorkExperiences);
        Assert.IsNotNull(receivedCv.SkillsAchievements);
    }

    [TearDown]
    public void TearDown()
    {
        _context.Database.EnsureDeleted();
        _context.Dispose();
    }
}
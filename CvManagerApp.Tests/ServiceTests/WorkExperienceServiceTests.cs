using CvManagerApp.Core.Models;
using CvManagerApp.Services;
using Microsoft.EntityFrameworkCore;

namespace CvManagerApp.Tests.ServiceTests;

[TestFixture]
public class WorkExperienceServiceTests
{
    private TestDbContext _context;
    private WorkExperienceService _service;
    private WorkExperience _workExperience;

    [SetUp]
    public void Setup()
    {
        var options = new DbContextOptionsBuilder<TestDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        _context = new TestDbContext(options);
        _service = new WorkExperienceService(_context);
        _workExperience = new WorkExperience
        {
            Company = "Test Company"
        };
        _context.WorkExperiences.Add(_workExperience);
        _context.SaveChanges();
    }

    [Test]
    public async Task DeleteWorkExperienceFromCv_DeletesWorkExperience()
    {
        // Act
        await _service.DeleteWorkExperienceFromCv(_workExperience.Id);

        // Assert
        var deletedWorkExperience = await _context.Educations.FindAsync(_workExperience.Id);
        Assert.IsNull(deletedWorkExperience);
    }

    [TearDown]
    public void TearDown()
    {
        _context.Database.EnsureDeleted();
        _context.Dispose();
    }
}
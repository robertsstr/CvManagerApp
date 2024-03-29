using CvManagerApp.Core.Models;
using CvManagerApp.Services;
using Microsoft.EntityFrameworkCore;

namespace CvManagerApp.Tests.ServiceTests;

[TestFixture]
public class EducationServiceTests
{
    private TestDbContext _context;
    private EducationService _service;
    private Education _education;

    [SetUp]
    public void Setup()
    {
        var options = new DbContextOptionsBuilder<TestDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        _context = new TestDbContext(options);
        _service = new EducationService(_context);
        _education = new Education
        {
            EducationalEstablishment = "Test Unitversity"
        };
        _context.Educations.Add(_education);
        _context.SaveChanges();
    }

    [Test]
    public async Task DeleteEducationFromCv_DeletesEducation()
    {
        // Act
        await _service.DeleteEducationFromCv(_education.Id);

        // Assert
        var deletedEducation = await _context.Educations.FindAsync(_education.Id);
        Assert.IsNull(deletedEducation);
    }

    [TearDown]
    public void TearDown()
    {
        _context.Database.EnsureDeleted();
        _context.Dispose();
    }
}
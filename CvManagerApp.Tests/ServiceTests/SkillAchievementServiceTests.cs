using CvManagerApp.Core.Models;
using CvManagerApp.Services;
using Microsoft.EntityFrameworkCore;

namespace CvManagerApp.Tests.ServiceTests;

public class SkillAchievementServiceTests
{
    private TestDbContext _context;
    private SkillAchievementService _service;
    private SkillAchievement _skillAchievement;

    [SetUp]
    public void Setup()
    {
        var options = new DbContextOptionsBuilder<TestDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        _context = new TestDbContext(options);
        _service = new SkillAchievementService(_context);
        _skillAchievement = new SkillAchievement
        {
            SkillOrAchievement = "Unit Tester"
        };
        _context.SkillsAchievements.Add(_skillAchievement);
        _context.SaveChanges();
    }

    [Test]
    public async Task DeleteSkillAchievementFromCv_DeletesSkillAchievement()
    {
        // Act
        await _service.DeleteSkillAchievementFromCv(_skillAchievement.Id);

        // Assert
        var deletedEducation = await _context.Educations.FindAsync(_skillAchievement.Id);
        Assert.IsNull(deletedEducation);
    }

    [TearDown]
    public void TearDown()
    {
        _context.Database.EnsureDeleted();
        _context.Dispose();
    }
}
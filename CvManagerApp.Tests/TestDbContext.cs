using CvManagerApp.Core.Models;
using CvManagerApp.Tests.Models;
using Microsoft.EntityFrameworkCore;

namespace CvManagerApp.Tests;

public class TestDbContext : DbContext
{
    public TestDbContext(DbContextOptions<TestDbContext> options) : base(options) { }

    public DbSet<TestEntity> TestEntities { get; set; }
    public DbSet<Cv> Cvs { get; set; }
    public DbSet<Education>? Educations { get; set; }
    public DbSet<WorkExperience>? WorkExperiences { get; set; }
    public DbSet<SkillAchievement>? SkillsAchievements { get; set; }
}
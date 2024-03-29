using CvManagerApp.Core.Models;
using CvManagerApp.Data.SeedData;
using Microsoft.EntityFrameworkCore;

namespace CvManagerApp.Data
{
    public class CvManagerDbContext : DbContext
    {
        public CvManagerDbContext(DbContextOptions<CvManagerDbContext> options) : base(options)
        {
        }

        public DbSet<Cv> Cvs { get; set; }
        public DbSet<Education>? Educations { get; set; }
        public DbSet<WorkExperience>? WorkExperiences { get; set; }
        public DbSet<SkillAchievement>? SkillsAchievements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("LATIN1_GENERAL_100_CI_AS_SC_UTF8");

            modelBuilder.Entity<Cv>()
                .HasMany(cv => cv.Educations)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Cv>()
                .HasMany(cv => cv.WorkExperiences)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Cv>()
                .HasMany(cv => cv.SkillsAchievements)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

using System.ComponentModel.DataAnnotations;

namespace CvManagerApp.Core.Models
{
    public class Cv
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? PhoneNumber { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        public string? DateOfBirth { get; set; }

        public List<Education>? Educations { get; set; }
        public List<WorkExperience>? WorkExperiences { get; set; }
        public List<SkillAchievement>? SkillsAchievements { get; set; }
    }
}

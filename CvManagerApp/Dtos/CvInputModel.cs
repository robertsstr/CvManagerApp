using System.ComponentModel.DataAnnotations;

namespace CvManagerApp.Dtos;

public class CvInputModel
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string? PhoneNumber { get; set; }
    [EmailAddress]
    public string? Email { get; set; }
    public string? DateOfBirth { get; set; }
    public List<EducationInputModel> Educations { get; set; }
    public List<WorkExperienceInputModel> WorkExperiences { get; set; }
    public List<SkillAchievementInputModel> SkillsAchievements { get; set; }
}
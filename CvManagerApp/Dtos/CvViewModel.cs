using System.ComponentModel.DataAnnotations;

namespace CvManagerApp.Dtos;

public class CvViewModel
{
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string? PhoneNumber { get; set; }
    [EmailAddress]
    public string? Email { get; set; }
    public string? DateOfBirth { get; set; }
    public List<EducationViewModel>? Educations { get; set; }
    public List<WorkExperienceViewModel>? WorkExperiences { get; set; }
    public List<SkillAchievementViewModel>? SkillsAchievements { get; set; }
}
namespace CvManagerApp.Core.Models;

public class Education
{
    public int Id { get; set; }
    public string? EducationalEstablishment { get; set; }
    public string? Faculty { get; set; }
    public string? StudyProgram { get; set; }
    public string? StudyStatus { get; set; }
    public int CvId { get; set; }
}
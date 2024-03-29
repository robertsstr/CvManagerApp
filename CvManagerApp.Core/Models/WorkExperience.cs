namespace CvManagerApp.Core.Models;

public class WorkExperience
{
    public int Id { get; set; }
    public string? Company { get; set; }
    public string? Position { get; set; }
    public string? StartDate { get; set; }
    public string? EndDate { get; set; }
    public int CvId { get; set; }
}
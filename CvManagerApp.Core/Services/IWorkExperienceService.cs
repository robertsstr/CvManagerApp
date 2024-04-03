using CvManagerApp.Core.Models;

namespace CvManagerApp.Core.Services;

public interface IWorkExperienceService : IEntityService<WorkExperience>
{
    Task DeleteWorkExperienceFromCv(int workExperienceId);
}
using CvManagerApp.Core.Models;
using CvManagerApp.Core.Services;
using Microsoft.EntityFrameworkCore;

namespace CvManagerApp.Services;

public class WorkExperienceService : EntityService<WorkExperience>, IWorkExperienceService
{
    public WorkExperienceService(DbContext context) : base(context)
    {
    }

    public async Task DeleteWorkExperienceFromCv(int workExperienceId)
    {
        await Delete(workExperienceId);
    }
}
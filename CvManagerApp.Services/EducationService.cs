using CvManagerApp.Core.Models;
using CvManagerApp.Core.Services;
using Microsoft.EntityFrameworkCore;

namespace CvManagerApp.Services;

public class EducationService : EntityService<Education>, IEducationService
{
    public EducationService(DbContext context) : base(context)
    {
    }

    public async Task DeleteEducationFromCv(int educationId)
    {
        await Delete(educationId);
    }
}
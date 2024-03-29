using CvManagerApp.Core.Models;

namespace CvManagerApp.Core.Services;

public interface IEducationService : IEntityService<Education>
{
    Task DeleteEducationFromCv(int educationId);
}
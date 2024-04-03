using CvManagerApp.Core.Models;

namespace CvManagerApp.Core.Services;

public interface ICvService : IEntityService<Cv>
{
    Task<bool> CvExists(Cv cv);
    Task<Cv> GetFullCv(int id);
}
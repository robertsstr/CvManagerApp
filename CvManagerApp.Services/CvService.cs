using CvManagerApp.Core.Models;
using CvManagerApp.Core.Services;
using Microsoft.EntityFrameworkCore;

namespace CvManagerApp.Services;

public class CvService : EntityService<Cv>, ICvService
{
    public CvService(DbContext context) : base(context)
    {
    }

    public async Task<bool> CvExists(Cv cv)
    {
        return await _context.Set<Cv>().AnyAsync(c =>
            c.FirstName == cv.FirstName &&
            c.LastName == cv.LastName &&
            c.PhoneNumber == cv.PhoneNumber);
    }

    public async Task<Cv> GetFullCv(int id)
    {
        return await _context.Set<Cv>()
            .Include(cv => cv.Educations)
            .Include(cv => cv.WorkExperiences)
            .Include(cv => cv.SkillsAchievements)
            .FirstOrDefaultAsync(cv => cv.Id == id); ;
    }
}
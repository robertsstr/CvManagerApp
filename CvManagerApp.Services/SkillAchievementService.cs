using CvManagerApp.Core.Models;
using CvManagerApp.Core.Services;
using Microsoft.EntityFrameworkCore;

namespace CvManagerApp.Services;

public class SkillAchievementService : EntityService<SkillAchievement>, ISkillAchievementService
{
    public SkillAchievementService(DbContext context) : base(context)
    {
    }

    public async Task DeleteSkillAchievementFromCv(int skillAchievementId)
    {
        await Delete(skillAchievementId);
    }
}
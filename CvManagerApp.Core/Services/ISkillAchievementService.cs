using CvManagerApp.Core.Models;

namespace CvManagerApp.Core.Services;

public interface ISkillAchievementService : IEntityService<SkillAchievement>
{
    Task DeleteSkillAchievementFromCv(int skillAchievementId);
}
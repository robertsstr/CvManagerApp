using CvManagerApp.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace CvManagerApp.Controllers;

[Route("skillachievement")]
public class SkillAchievementController : Controller
{
    private readonly ISkillAchievementService _skillAchievementService;

    public SkillAchievementController(ISkillAchievementService skillAchievementService)
    {
        _skillAchievementService = skillAchievementService;
    }

    [HttpDelete("delete/{skillAchievementId}")]
    public async Task<IActionResult> Delete(int skillAchievementId)
    {
        await _skillAchievementService.DeleteSkillAchievementFromCv(skillAchievementId);

        return Ok();
    }
}
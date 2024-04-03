using CvManagerApp.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace CvManagerApp.Controllers;

[Route("workexperience")]
public class WorkExperienceController : Controller
{
    private readonly IWorkExperienceService _workExperienceService;

    public WorkExperienceController(IWorkExperienceService workExperienceService)
    {
        _workExperienceService = workExperienceService;
    }

    [HttpDelete("delete/{workExperienceId}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int workExperienceId)
    {
        await _workExperienceService.DeleteWorkExperienceFromCv(workExperienceId);

        return Ok();
    }
}
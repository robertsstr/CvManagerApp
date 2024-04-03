using CvManagerApp.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace CvManagerApp.Controllers;

[Route("education")]
public class EducationController : Controller
{
    private readonly IEducationService _educationService;

    public EducationController(IEducationService educationService)
    {
        _educationService = educationService;
    }

    [HttpDelete("delete/{educationId}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int educationId)
    {
        await _educationService.DeleteEducationFromCv(educationId);

        return Ok();
    }
}
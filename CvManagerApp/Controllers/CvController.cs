using AutoMapper;
using CvManagerApp.Core.Models;
using CvManagerApp.Core.Services;
using CvManagerApp.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace CvManagerApp.Controllers;

public class CvController : Controller
{
    private readonly ICvService _cvService;
    private readonly IMapper _mapper;

    public CvController(ICvService cvService, IMapper mapper)
    {
        _cvService = cvService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> Home()
    {
        var cvs = await _cvService.GetAll();

        return View(cvs);
    }

    [HttpGet]
    [Route("/create")]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Route("/create")]
    public async Task<IActionResult> Create(CvInputModel cvInput)
    {
        var cv = _mapper.Map<Cv>(cvInput);
        if (await _cvService.CvExists(cv))
            return PartialView("_DuplicateCvMessage");

        await _cvService.Create(cv);

        return RedirectToAction("Home");
    }

    [HttpGet]
    [Route("view")]
    public async Task<IActionResult> ViewFullCv(int id)
    {
        var cv = await _cvService.GetFullCv(id);
        var cvView = _mapper.Map<CvViewModel>(cv);

        return View(cvView);
    }

    [HttpGet]
    [Route("/edit/{id}")]
    public async Task<IActionResult> Edit(int id)
    {
        var cv = await _cvService.GetFullCv(id);
        var cvDto = _mapper.Map<CvViewModel>(cv);

        return View(cvDto);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Route("/edit/{id}")]
    public async Task<IActionResult> Edit(int id, CvViewModel cvEdited)
    {
        var cv = _mapper.Map<Cv>(cvEdited);
        await _cvService.Update(cv);

        return RedirectToAction("Home");
    }

    [HttpGet]
    [Route("/cv/delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var cv = await _cvService.GetFullCv(id);

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Route("/cv/delete/{id}")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _cvService.Delete(id);

        return RedirectToAction("Home");
    }

    [HttpGet]
    [Route("privacy")]
    public IActionResult Privacy()
    {
        return View();
    }
}
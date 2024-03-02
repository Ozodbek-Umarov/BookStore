using Book.BusinessLogic.Common;
using Book.BusinessLogic.DTOs.JanrDTOs;
using Book.BusinessLogic.Interfaces;
using Book.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Book.Controllers;

public class JanrsController(IJanrService janrService)
    : Controller
{
    private readonly IJanrService _janrService = janrService;

    public IActionResult Index()
    {
        var janrs = _janrService.GetAll();
        return View(janrs);
    }
    public IActionResult Add()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Add(AddJanrDto dto)
    {
        try
        {
            _janrService.Create(dto);
            return RedirectToAction("Index");
        }
        catch (CustomExeption ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(dto);
        }
    }
    public IActionResult Delete(int id)
    {
        try
        {
            _janrService.Delete(id);
            return RedirectToAction("Index");
        }
        catch (CustomExeption)
        {
            return RedirectToAction("Error", "Home", new { url = "/janrs/index" });
        }
    }
    public IActionResult Edit(int id)
    {
        try
        {
            var janr = _janrService.GetById(id);
            UpdateJanrDto dto = new()
            {
                Id = janr.Id,
                Name = janr.Name,
                ImagePath = janr.ImagePath
            };
            return View(dto);
        }
        catch (CustomExeption)
        {
            return RedirectToAction("Error", "Home", new { url = "/janrs/index" });
        }
    }

    [HttpPost]
    public IActionResult Edit(UpdateJanrDto dto)
    {
        try
        {
            _janrService.Update(dto);
            return RedirectToAction("Index");
        }
        catch (CustomExeption ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(dto);
        }
    }
}

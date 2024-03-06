using Book.BusinessLogic.Common;
using Book.BusinessLogic.DTOs.JanrDTOs;
using Book.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Book.Areas.Admin.Controllers;

[Area("admin")]
[Authorize(AuthenticationSchemes = "Admin")]
public class JanrsController(IJanrService janrService)
    : Controller
{
    private readonly IJanrService _janrService = janrService;


    public IActionResult Index(int pageNumber = 1)
    {
        var janrs = _janrService.GetAll();
        var pageModel = new PageModel<JanrDto>(janrs, pageNumber);
        return View(pageModel);
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
            var dto = new UpdateJanrDto
            {
                Id = janr.Id,
                Name = janr.Name
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

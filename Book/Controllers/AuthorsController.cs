using Book.BusinessLogic.Common;
using Book.BusinessLogic.DTOs.AuthorDTOs;
using Book.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Book.Controllers;

public class AuthorsController(IAuthorService Authorservice) 
    : Controller
{
    private readonly IAuthorService _Authorservice = Authorservice;


    public IActionResult Index(int pageNumber = 1)
    {
        var Authors = _Authorservice.GetAll();
        var pageModel = new PageModel<AuthorDto>(Authors, pageNumber);
        return View(pageModel);
    }

    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Add(AddAuthorDto dto)
    {
        try
        {
            _Authorservice.Create(dto);
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
            _Authorservice.Delete(id);
            return RedirectToAction("Index");
        }
        catch (CustomExeption)
        {
            return RedirectToAction("Error", "Home", new { url = "/authors/index" });
        }
    }

    public IActionResult Edit(int id)
    {
        try
        {
            var author = _Authorservice.GetById(id);
            var dto = new UpdateAuthorDto
            {
                Id = author.Id,
                Name = author.Name
            };
            return View(dto);
        }
        catch (CustomExeption)
        {
            return RedirectToAction("Error", "Home", new { url = "/authors/index" });
        }
    }

    [HttpPost]
    public IActionResult Edit(UpdateAuthorDto dto)
    {
        try
        {
            _Authorservice.Update(dto);
            return RedirectToAction("Index");
        }
        catch (CustomExeption ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(dto);
        }
    }
}

using Book.BusinessLogic.Common;
using Book.BusinessLogic.DTOs.BookDTOs;
using Book.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Book.Controllers;

public class BooksController(IBookService bookService,
                            IJanrService janrService,
                            IAuthorService authorService)
    : Controller
{
    private readonly IBookService _bookService = bookService;
    private readonly IJanrService _janrService = janrService;
    private readonly IAuthorService _authorService = authorService;

    public IActionResult Index()
    {
        var kitoblar = _bookService.GetAll();
        var pageModel = new PageModel<BookDto>(kitoblar, 1);
        return View(pageModel);
    }
    public IActionResult Add()
    {
        var janrlar = _janrService.GetAll();
        var mualliflar = _authorService.GetAll();
        AddBookDto dto = new AddBookDto
        {
            Janrlar = janrlar,
            Mualliflar = mualliflar
        };
        return View(dto);
    }
    [HttpPost]
    public IActionResult Add(AddBookDto dto)
    {
        try
        {
            _bookService.Create(dto);
            return RedirectToAction("Index");
        }
        catch (CustomExeption ex)
        {
            ModelState.AddModelError(ex.Key, ex.Message);
            return View(dto);
        }
    }
    public IActionResult Delete(int id)
    {
        try
        {
            _bookService.Delete(id);
            return RedirectToAction("Index");
        }
        catch (CustomExeption)
        {
            return RedirectToAction("error", "home", new { url = "/janrs/index" });
        }
    }
    public IActionResult Edit(int id)
    {
        try
        {
            var kitob = _bookService.GetById(id);
            UpdateBookDto dto = new UpdateBookDto
            {
                Id = kitob.Id,
                Name = kitob.Name,
                Description = kitob.Description,
                Price = kitob.Price,
                AuthorId = kitob.Author.Id,
                JanrId = kitob.Janr.Id,
               //file = kitob.ImagePath
            };
            return View(dto);
        }
        catch (CustomExeption)
        {
            return RedirectToAction("error", "home", new { url = "/janrs/index" });
        }
    }
    [HttpPost]
    public IActionResult Edit(UpdateBookDto dto)
    {
        try
        {
            _bookService.Update(dto);
            return RedirectToAction("Index");
        }
        catch (CustomExeption ex)
        {
            ModelState.AddModelError(ex.Key, ex.Message);
            return View(dto);
        }
    }
    public IActionResult Details(int id)
    {
        try
        {
            var kitob = _bookService.GetById(id);
            return View(kitob);
        }
        catch (CustomExeption)
        {
            return RedirectToAction("error", "home", new { url = "/janrs/index" });
        }
    }
}
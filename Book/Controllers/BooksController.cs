using Book.BusinessLogic.Common;
using Book.BusinessLogic.DTOs.BookDTOs;
using Book.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Book.Controllers;

public class BooksController(IBookService bookService)
    : Controller
{
    private readonly IBookService _bookService = bookService;

    public IActionResult Index()
    {
        var kitoblar = _bookService.GetAll();
        var pageModel = new PageModel<BookDto>(kitoblar, 1);
        return View(pageModel);
    }
}

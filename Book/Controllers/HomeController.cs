using Book.BusinessLogic.Common;
using Book.BusinessLogic.DTOs.BookDTOs;
using Book.BusinessLogic.Interfaces;
using Book.Models;
using Microsoft.AspNetCore.Mvc;

namespace Book.Controllers;

public class HomeController(IAuthorService authorService,
                            IBookService bookService,
                            IJanrService janrService,
                            IAuthService authService,
                            IFileService fileService)
    : Controller
{
    private readonly IAuthorService authorService = authorService;
    private readonly IBookService bookService = bookService;
    private readonly IJanrService janrService = janrService;
    private readonly IFileService fileService = fileService;
    private readonly IAuthService authService = authService;

    public IActionResult Index()
    {
        var res = HttpContext.User;


        var books = bookService.GetAll();
        var authors = authorService.GetAll();
        var janrs = janrService.GetAll();

        IndexViewModel viewModel = new()
        {
            Books = books.Take(9).ToList(),
            Authors = authors,
            Janrs = janrs
        };

        return View(viewModel);
    }

    public IActionResult More(int id)
    {
        var book = bookService.GetById(id);
        return View(book);
    }

    public IActionResult Books(int pageNumber = 1)
    {
        var books = bookService.GetAll();
        var pageModel = new PageModel<BookDto>(books, pageNumber, 12);
        var janrs = janrService.GetAll();

        BooksViewModel viewModel = new()
        {
            PageModel = pageModel,
            JanrChecks = janrs.Select(c => new JanrCheck()
            { Id = c.Id, Name = c.Name }
                                                    ).ToList()
        };

        return View(viewModel);
    }

}

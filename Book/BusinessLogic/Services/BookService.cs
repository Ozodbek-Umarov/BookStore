using Book.BusinessLogic.Common;
using Book.BusinessLogic.DTOs.AuthorDTOs;
using Book.BusinessLogic.DTOs.BookDTOs;
using Book.BusinessLogic.DTOs.JanrDTOs;
using Book.BusinessLogic.Interfaces;
using Book.Data;
using Book.Data.Entities;
using Book.Data.Interfaces;

namespace Book.BusinessLogic.Services;

public class BookService(IUnitOfWork unitOfWork)
    : IBookService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public void Create(AddBookDto bookDto)
    {
        if (bookDto is null)
        {
            throw new CustomExeption("", "BookDto was null");
        }
        if (string.IsNullOrEmpty(bookDto.Name))
        {
            throw new CustomExeption("", "Name was null");
        }
        Books book = new()
        {
            Name = bookDto.Name,
            Title = bookDto.Description,
            Price = bookDto.Price,
            AuthorId = bookDto.AuthorId,
            JanrId = bookDto.JanrId,
            ImagePath = bookDto.ImagePath
        };
        _unitOfWork.Books.Add(book);
    }

    public void Delete(int id)
    {
        var book = _unitOfWork.Books.GetById(id);
        if (book is null)
        {
            throw new CustomExeption("", "Book not found");
        }
        _unitOfWork.Books.Delete(book.Id);
    }

    public List<BookDto> GetAll()
    {
        var books = _unitOfWork.Books.GetBooksWithReleations();
        var dtos = books.Select(book => book.ToBookDto());
        return dtos.ToList();
    }

    public BookDto GetById(int id)
    {
        var book = _unitOfWork.Books.GetById(id);
        if (book is null)
        {
            throw new CustomExeption("", "Book not found");
        }
        return book.ToBookDto();
    }

    public void Update(UpdateBookDto bookDto)
    {
        var book = _unitOfWork.Books.GetById(bookDto.Id);
        if (book is null)
        {
            throw new CustomExeption("", "Book not found");
        }
        book.Name = bookDto.Name;
        book.Title = bookDto.Description;
        book.Price = bookDto.Price;
        book.AuthorId = bookDto.AuthorId;
        book.JanrId = bookDto.JanrId;
        book.ImagePath = bookDto.ImagePath;
        _unitOfWork.Books.Update(book);
    }
}

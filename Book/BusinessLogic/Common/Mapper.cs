using Book.BusinessLogic.DTOs.AuthorDTOs;
using Book.BusinessLogic.DTOs.BookDTOs;
using Book.BusinessLogic.DTOs.JanrDTOs;
using Book.Data.Entities;

namespace Book.BusinessLogic.Common;

public static class Mapper
{
    /*public static JanrDto ToBookDto(this Janr janr)
        => new()
        {
            Id = janr.Id,
            Name = janr.Name
        };
    public static AuthorDto ToAuthorDto(this Author author)
        => new()
        {
            Id = author.Id,
            Name = author.Name
        };
    public static BookDto ToBookDto(this Books book)
        => new()
        {
            Id = book.Id,
            Name = book.Name,
            Description = book.Title,
            Price = book.Price,
            Author = book.Author.ToAuthorDto(),
            Janr = book.Janr.ToBookDto(),
            ImagePath = book.ImagePath
        };*/
    public static BookDto ToBookDto(this Books book)
        => new()
        {
            Id = book.Id,
            Name = book.Name,
            Description = book.Title,
            Price = book.Price,
            Janr = (JanrDto)book.Janr,
            Author = (AuthorDto)book.Author,
            ImagePath = book.ImagePath
        };
}

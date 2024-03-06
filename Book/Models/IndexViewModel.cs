using Book.BusinessLogic.DTOs.AuthorDTOs;
using Book.BusinessLogic.DTOs.BookDTOs;
using Book.BusinessLogic.DTOs.JanrDTOs;

namespace Book.Models;

public class IndexViewModel
{
    public List<BookDto> Books { get; set; } = new();
    public List<AuthorDto> Authors { get; set; } = new();
    public List<JanrDto> Janrs { get; set; } = new();
}

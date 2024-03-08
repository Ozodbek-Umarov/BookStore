using Book.BusinessLogic.Common;
using Book.BusinessLogic.DTOs.BookDTOs;
namespace Book.Models;

public class BooksViewModel
{
    public PageModel<BookDto>? PageModel { get; set; }
    public List<JanrCheck>? JanrChecks { get; set; }
}

public class JanrCheck
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool IsChecked { get; set; }
}

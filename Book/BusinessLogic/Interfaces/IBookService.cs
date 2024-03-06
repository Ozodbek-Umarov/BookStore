using Book.BusinessLogic.DTOs.BookDTOs;

namespace Book.BusinessLogic.Interfaces;

public interface IBookService
{
    List<BookDto> GetAll();
    BookDto GetById(int id);
    void Create(AddBookDto bookDto);
    void Update(UpdateBookDto bookDto);
    void Delete(int id);
}

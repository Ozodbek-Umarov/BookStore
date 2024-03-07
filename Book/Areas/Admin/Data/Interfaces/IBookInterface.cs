using Book.Data.Entities;

namespace Book.Data.Interfaces;

public interface IBookInterface : IRepository<Books>
{
    List<Books> GetBooksWithReleations();
}

using Book.Data.Entities;
using Book.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Book.Data.Repositories;

public class BookRepository : Repository<Books>, IBookInterface
{
    private readonly AppDbContext _dbContext;

    public BookRepository(AppDbContext dbContext)
        : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Books> GetBooksWithReleations()
    {
        return _dbContext.Books
            .Include(b => b.Author)
            .Include(b => b.Janr)
            .ToList();
    }
}
using Book.Data;
using Book.Data.Interfaces;
using Book.Data.Repositories;

namespace Book.Areas.Admin.Data.Repositories
{
    public class UnitOfWork(AppDbContext dbContext)
        : IUnitOfWork
    {
        public IAuthorInterface Authors => new AuthorRepository(dbContext);

        public IBookInterface Books => new BookRepository(dbContext);
    }
}

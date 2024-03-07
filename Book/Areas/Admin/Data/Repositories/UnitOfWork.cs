using Book.Data.Interfaces;

namespace Book.Data.Repositories;

public class UnitOfWork(AppDbContext dbContext)
    : IUnitOfWork
{
    public IAuthorInterface Authors => new AuthorRepository(dbContext);

    public IBookInterface Books => new BookRepository(dbContext);

    public IImageInterface imageInterface => new ImageRepository(dbContext);

    public IJanrInterface Janrs => new JanrRepository(dbContext);

    public IOrderInterface Orders => new OrderRepository(dbContext);

    public IUserInterface Users => new UserRepository(dbContext);
}

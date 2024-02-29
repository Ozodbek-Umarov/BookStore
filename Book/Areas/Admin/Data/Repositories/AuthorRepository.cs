using Book.Data.Entities;
using Book.Data.Interfaces;

namespace Book.Data.Repositories;

public class AuthorRepository(AppDbContext dbContext)
    : Repository<Author>(dbContext) , IAuthorInterface
{
}

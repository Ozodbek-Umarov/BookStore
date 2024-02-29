using Book.Data.Entities;
using Book.Data.Interfaces;

namespace Book.Data.Repositories;

public class GenreRepository(AppDbContext dbContext)
    : Repository<Genre>(dbContext), IGenreInterface
{
}

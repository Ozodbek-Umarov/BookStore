using Book.Areas.Admin.Interfaces;
using Book.Data.Entities;
using Book.Data.Interfaces;

namespace Book.Data.Repositories;

public class JanrRepository(AppDbContext dbContext)
    : Repository<Janr>(dbContext), IJanrInterface
{
}

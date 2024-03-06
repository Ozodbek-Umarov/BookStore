using Book.Data.Entities;
using Book.Data.Interfaces;

namespace Book.Data.Repositories;

public class UserRepository(AppDbContext dbContext)
    : Repository<User>(dbContext), IUserInterface
{
}

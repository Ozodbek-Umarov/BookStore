using Book.Data.Entities;
using Book.Data.Interfaces;

namespace Book.Data.Repositories;

public class OrderRepository(AppDbContext dbContext)
    : Repository<Order>(dbContext), IOrderInterface
{
}

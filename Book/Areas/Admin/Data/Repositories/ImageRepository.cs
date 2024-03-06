using Book.Data.Entities;
using Book.Data.Interfaces;

namespace Book.Data.Repositories;

public class ImageRepository(AppDbContext dbContext)
    : Repository<Image>(dbContext), IImageInterface
{
}

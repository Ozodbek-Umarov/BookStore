using Book.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Book.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItems> OrderItems { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Books> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Genre> Janrs { get; set; }
}

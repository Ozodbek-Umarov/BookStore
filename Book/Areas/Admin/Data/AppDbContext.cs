using Book.BusinessLogic.Services;
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
    public DbSet<Janr> Janrs { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        User superUser = new()
        {
            Id = 11111111,
            FullName = "Super Admin",
            TelNomer = "+998901234567",
            Password = PasswordHasher.HashPassword("Super.Admin"),
            Address = "Database",
            Role = Role.Admin
        };

        modelBuilder.Entity<User>()
            .HasData(superUser);

        base.OnModelCreating(modelBuilder);
    }

}

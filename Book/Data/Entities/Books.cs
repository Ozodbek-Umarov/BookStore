namespace Book.Data.Entities;

public class Books : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Title { get; set; } = null!;
    public double Price { get; set; }
    public int AuthorId { get; set; }
    public Author Author { get; set; } = new Author();
    public int GenreId { get; set; }

    public Genre Genre { get; set; } = new Genre();
    public ICollection<OrderItems> OrderItems { get; set; } = new List<OrderItems>();
}

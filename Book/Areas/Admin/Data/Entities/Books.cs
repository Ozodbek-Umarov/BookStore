using Book.Areas.Admin.Entities;

namespace Book.Data.Entities;

public class Books : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Title { get; set; } = null!;
    public double Price { get; set; }
    public int AuthorId { get; set; }
    public Author Author { get; set; } = new Author();
    public int JanrId { get; set; }
    public string ImagePath { get; set; } = null!;
    public Janr Janr { get; set; } = new Janr();
    public ICollection<OrderItems> OrderItems { get; set; } = new List<OrderItems>();
}

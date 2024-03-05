namespace Book.Data.Entities;

public class Genre : BaseEntity
{
    public string Name { get; set; } = null!;
    public ICollection<Books> Books { get; set; } = new List<Books>();
}

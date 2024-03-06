namespace Book.Data.Entities;

public class Janr : BaseEntity
{
    public string Name { get; set; } = null!;
    public ICollection<Books> Books { get; set; } = new List<Books>();
}

namespace Book.Data.Entities;

public class Image : BaseEntity
{
    public string Url { get; set; } = null!;
    public int BookId { get; set; }
    public Books Book { get; set; } = new Books();
}

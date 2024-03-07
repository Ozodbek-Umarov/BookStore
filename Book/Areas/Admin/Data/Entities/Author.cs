using Book.Areas.Admin.Entities;

namespace Book.Data.Entities;

public class Author : BaseEntity
{
    public string Name { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;

    public ICollection<Books> Books { get; set; } = new List<Books>();
}

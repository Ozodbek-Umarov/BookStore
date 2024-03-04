namespace Book.Data.Entities;

public class User   : BaseEntity
{
    public string FullName { get; set; } = null!;
    public string TelNomer { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Address { get; set; } = null!;
    public ICollection<Order> Orders { get; set; } = new List<Order>();
}

namespace Book.Data.Entities;

public class OrderItems : BaseEntity
{
    public Books Book { get; set; } = new Books();
    public int BookId { get; set; }
    public Order Order { get; set; } = new Order();
    public int OrderId { get; set; }
}

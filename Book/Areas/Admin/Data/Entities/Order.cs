namespace Book.Data.Entities;

public class Order : BaseEntity
{
    public User User { get; set; } = new User();
    public int UserId { get; set; }
    public double TotalAmount { get; set; }
    public DateTime Date { get; set; }
    public ICollection<OrderItems> OrderItems { get; set; } = new List<OrderItems>();
}

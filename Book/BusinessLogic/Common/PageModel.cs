namespace Book.BusinessLogic.Common;

public class PageModel<T>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalPages { get; set; }
    public int TotalItemsCount { get; set; }
    public List<T> Items { get; set; } = new();
}

namespace Book.BusinessLogic.DTOs.BookDTOs;

public class AddBookDto
{
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public double Price { get; set; }
    public int AuthorId { get; set; }
    public int JanrId { get; set; }
    public string ImagePath { get; set; } = "";
}

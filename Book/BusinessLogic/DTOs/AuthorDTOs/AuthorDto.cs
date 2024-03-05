using Book.Data.Entities;

namespace Book.BusinessLogic.DTOs.AuthorDTOs;

public class AuthorDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string ImagePath { get; set; } = null!;
    public static implicit operator AuthorDto(Author author)
        => new()
        {
            Id = author.Id,
            Name = author.Name,
            ImagePath = author.ImageUrl
        };
}

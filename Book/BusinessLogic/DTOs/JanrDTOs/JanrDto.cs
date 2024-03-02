using Book.Data.Entities;

namespace Book.BusinessLogic.DTOs.JanrDTOs;

public class JanrDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string ImagePath { get; set; } = null!;
    public static implicit operator JanrDto(Janr janr)
        => new()
        {
            Id = janr.Id,
            Name = janr.Name,
            ImagePath = janr.ImageUrl
        };
}
namespace Book.BusinessLogic.DTOs.JanrDTOs;

public class UpdateJanrDto : JanrDto
{
    public IFormFile file { get; set; } = null!;
}

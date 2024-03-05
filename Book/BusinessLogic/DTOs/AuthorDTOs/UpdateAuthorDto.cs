namespace Book.BusinessLogic.DTOs.AuthorDTOs;

public class UpdateAuthorDto : AuthorDto
{
    public IFormFile? file { get; set; }
}

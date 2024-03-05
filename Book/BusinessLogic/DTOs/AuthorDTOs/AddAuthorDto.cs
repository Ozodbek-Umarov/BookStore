using Book.BusinessLogic.DTOs.JanrDTOs;

namespace Book.BusinessLogic.DTOs.AuthorDTOs;

public class AddAuthorDto : AddJanrDto
{
    public IFormFile? file { get; set; }
}

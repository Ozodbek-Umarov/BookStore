using Book.BusinessLogic.DTOs.AuthorDTOs;
using Book.BusinessLogic.DTOs.JanrDTOs;

namespace Book.BusinessLogic.DTOs.BookDTOs
{
    public class AddBookDto
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public double Price { get; set; }
        public int AuthorId { get; set; }
        public int JanrId { get; set; }
        public IFormFile? file { get; set; }
        public List<JanrDto> Janrlar { get; set; } = new();
        public List<AuthorDto> Mualliflar { get; set; } = new();
    }
}

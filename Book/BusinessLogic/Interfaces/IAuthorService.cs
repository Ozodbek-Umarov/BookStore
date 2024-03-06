using Book.BusinessLogic.DTOs.AuthorDTOs;

namespace Book.BusinessLogic.Interfaces;

public interface IAuthorService
{
    List<AuthorDto> GetAll();
    AuthorDto GetById(int id);
    void Create(AddAuthorDto authorDto);
    void Update(UpdateAuthorDto authorDto);
    void Delete(int id);
}

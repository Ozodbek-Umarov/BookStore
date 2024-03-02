using Book.BusinessLogic.DTOs.JanrDTOs;

namespace Book.BusinessLogic.Interfaces;

public interface IJanrService
{
    List<JanrDto> GetAll();
    JanrDto GetById(int id);
    void Create(AddJanrDto janrDto);
    void Update(UpdateJanrDto janrDto);
    void Delete(int id);
}

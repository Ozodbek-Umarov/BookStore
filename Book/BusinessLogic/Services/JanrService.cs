using Book.BusinessLogic.Common;
using Book.BusinessLogic.DTOs.JanrDTOs;
using Book.BusinessLogic.Interfaces;
using Book.Data.Entities;
using Book.Data.Interfaces;

namespace Book.BusinessLogic.Services;

public class JanrService(IUnitOfWork unitOfWork)
    : IJanrService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public void Create(AddJanrDto janrDto)
    {
        if (janrDto == null)
            throw new CustomExeption("JanrDto is null");
        if (string.IsNullOrEmpty(janrDto.Name))
            throw new CustomExeption("Janr Name is null or empty");
        if (janrDto.Name.Length < 3 || janrDto.Name.Length > 30)
            throw new CustomExeption("Janr Name must be beetween 3 and 30 characters");

        Janr janr = new()
        {
            Name = janrDto.Name
        };
        _unitOfWork.Janrs.Add(janr);
    }

    public void Delete(int id)
    {
        var janr = _unitOfWork.Janrs.GetById(id);
        if (janr == null)
            throw new CustomExeption("Janr not found");
        _unitOfWork.Janrs.Delete(janr.Id);
    }

    public List<JanrDto> GetAll()
    {
        var janrs = _unitOfWork.Janrs.GetAll();
        var list = janrs.Select(j => new JanrDto()
        {
            Id = j.Id,
            Name = j.Name
        }).ToList();
        return list;
    }

    public JanrDto GetById(int id)
    {
        var janr = _unitOfWork.Janrs.GetById(id);
        if (janr == null)
            throw new CustomExeption("Janr not found");

        var dto = new JanrDto()
        {
            Id = janr.Id,
            Name = janr.Name
        };
        return dto;
    }

    public void Update(JanrDto janrDto)
    {
        var janr = _unitOfWork.Janrs.GetById(janrDto.Id);
        if (janr == null)
            throw new CustomExeption("Janr not found");
        if (string.IsNullOrEmpty(janrDto.Name))
            throw new CustomExeption("Janr Name is null or empty");
        if (janrDto.Name.Length < 3 || janrDto.Name.Length > 30)
            throw new CustomExeption("Janr Name must be beetween 3 and 30 characters");

        var dto = new Janr()
        {
            Id = janrDto.Id,
            Name = janrDto.Name
        };
        _unitOfWork.Janrs.Update(dto);
    }
}

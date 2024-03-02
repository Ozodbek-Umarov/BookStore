using Book.BusinessLogic.Common;
using Book.BusinessLogic.DTOs.JanrDTOs;
using Book.BusinessLogic.Interfaces;
using Book.Data.Entities;
using Book.Data.Interfaces;

namespace Book.BusinessLogic.Services;

public class JanrService(IUnitOfWork unitOfWork,
                        IFileService fileService)
    : IJanrService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public IFileService _fileService = fileService;

    public void Create(AddJanrDto janrDto)
    {
        if (janrDto == null)
            throw new CustomExeption("","JanrDto is null");
        if (string.IsNullOrEmpty(janrDto.Name))
            throw new CustomExeption("Name","Janr Name is null or empty");
        if (janrDto.Name.Length < 3 || janrDto.Name.Length > 30)
            throw new CustomExeption("Name","Janr Name must be beetween 3 and 30 characters");
        if (janrDto.file == null)
            throw new CustomExeption("file","Image is null");

        Janr janr = new()
        {
            Name = janrDto.Name,
            ImageUrl = _fileService.UploadImage(janrDto.file)
        };
        _unitOfWork.Janrs.Add(janr);
    }

    public void Delete(int id)
    {
        var janr = _unitOfWork.Janrs.GetById(id);
        if (janr == null)
            throw new CustomExeption("","Janr not found");
        _fileService.DeleteImage(janr.ImageUrl);
        _unitOfWork.Janrs.Delete(janr.Id);
    }

    public List<JanrDto> GetAll()
    {
        var janrs = _unitOfWork.Janrs.GetAll();
        var list = janrs.Select(j => new JanrDto()
        {
            Id = j.Id,
            Name = j.Name,
            ImagePath = j.ImageUrl
        }).ToList();
        return list;
    }

    public JanrDto GetById(int id)
    {
        var janr = _unitOfWork.Janrs.GetById(id);
        if (janr == null)
            throw new CustomExeption("", "Janr not found");

        var dto = new JanrDto()
        {
            Id = janr.Id,
            Name = janr.Name,
            ImagePath = janr.ImageUrl
        };
        return dto;
    }

    public void Update(UpdateJanrDto janrDto)
    {
        var janr = _unitOfWork.Janrs.GetById(janrDto.Id);
        if (janr == null)
            throw new CustomExeption("", "Janr not found");
        if (string.IsNullOrEmpty(janrDto.Name))
            throw new CustomExeption("", "Janr Name is null or empty");
        if (janrDto.Name.Length < 3 || janrDto.Name.Length > 30)
            throw new CustomExeption("", "Janr Name must be beetween 3 and 30 characters");
        if (janrDto.file != null)
        {
            _fileService.DeleteImage(janr.ImageUrl);
            janrDto.ImagePath = _fileService.UploadImage(janrDto.file);
        }

        janr.Name = janrDto.Name;
        janr.ImageUrl = janrDto.ImagePath;
        _unitOfWork.Janrs.Update(janr);
    }
}

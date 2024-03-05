using AutoMapper;
using Book.BusinessLogic.Common;
using Book.BusinessLogic.DTOs.AuthorDTOs;
using Book.BusinessLogic.Interfaces;
using Book.Data.Entities;
using Book.Data.Interfaces;

namespace Book.BusinessLogic.Services;

public class AuthorService(IUnitOfWork unitOfWork,
                          IFileService fileService,
                          IMapper mapper)
    : IAuthorService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IFileService _fileService = fileService;
    private readonly IMapper _mapper = mapper;

    public void Create(AddAuthorDto authorDto)
    {
        if (authorDto == null)
            throw new CustomExeption("", "authorDto is null");
        if (string.IsNullOrEmpty(authorDto.Name))
            throw new CustomExeption("Name", "author Name is null or empty");
        if (authorDto.Name.Length < 3 || authorDto.Name.Length > 30)
            throw new CustomExeption("Name", "author Name must be beetween 3 and 30 characters");
        if (authorDto.file == null)
            throw new CustomExeption("file", "Image is null");

        Author author = new()
        {
            Name = authorDto.Name,
            ImageUrl = _fileService.UploadImage(authorDto.file)
        };
        _unitOfWork.Authors.Add(author);
    }

    public void Delete(int id)
    {
        var author = _unitOfWork.Authors.GetById(id);
        if (author == null)
            throw new CustomExeption("", "author not found");
        _fileService.DeleteImage(author.ImageUrl);
        _unitOfWork.Authors.Delete(author.Id);
    }

    public List<AuthorDto> GetAll()
    {
        var authors = _unitOfWork.Authors.GetAll();
        var list = authors.Select(j => new AuthorDto()
        {
            Id = j.Id,
            Name = j.Name,
            ImagePath = j.ImageUrl
        }).ToList();
        return list;
    }

    public AuthorDto GetById(int id)
    {
        var author = _unitOfWork.Authors.GetById(id);
        if (author == null)
            throw new CustomExeption("", "author not found");

        var dto = new AuthorDto()
        {
            Id = author.Id,
            Name = author.Name,
            ImagePath = author.ImageUrl
        };
        return dto;
    }

    public void Update(UpdateAuthorDto authorDto)
    {
        var author = _unitOfWork.Authors.GetById(authorDto.Id);
        if (author == null)
            throw new CustomExeption("", "author not found");
        if (string.IsNullOrEmpty(authorDto.Name))
            throw new CustomExeption("", "author Name is null or empty");
        if (authorDto.Name.Length < 3 || authorDto.Name.Length > 30)
            throw new CustomExeption("", "author Name must be beetween 3 and 30 characters");
        if (authorDto.file != null)
        {
            _fileService.DeleteImage(author.ImageUrl);
            authorDto.ImagePath = _fileService.UploadImage(authorDto.file);
        }

        author.Name = authorDto.Name;
        author.ImageUrl = authorDto.ImagePath;
        _unitOfWork.Authors.Update(author);
    }
}
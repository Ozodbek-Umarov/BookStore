using AutoMapper;
using Book.BusinessLogic.DTOs.AuthorDTOs;
using Book.Data.Entities;

namespace Book.BusinessLogic.Commonl;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Author, AuthorDto>()
            .ForMember(dest => dest.ImagePath, opt => opt.MapFrom(src => src.ImageUrl))
            .ReverseMap();
    }
}
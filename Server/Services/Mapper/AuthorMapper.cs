using AutoMapper;
using Blog.Server.Models;
using Blog.Shared.Models.DTO.AuthorDTOS;

namespace Blog.Server.Services.Mapper
{
    public class AuthorMapper : Profile
    {
        public AuthorMapper()
        {
            CreateMap<Author, AuthorDTO>()
                .ForMember(dest => dest.AuthorID, opt => opt.MapFrom(src => src.AuthorID))
                .ForMember(dest => dest.Login, opt => opt.MapFrom(src => src.Login))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(dest => dest.PostCount, opt => opt.MapFrom(src => src.Posts != null ? 1 : 0))
                .ReverseMap();
        }
    }

}

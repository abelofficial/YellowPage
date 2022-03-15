using AutoMapper;
using YellowPage.Api.Dtos;
using YellowPage.Api.Models;

namespace YellowPage.Api.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<PersonRequestDto, Person>()
            .ForMember(
                dest => dest.FirstName,
                opt => opt.MapFrom(src => src.FirstName)
            )
            .ForMember(
                dest => dest.LastName,
                opt => opt.MapFrom(src => src.LastName)
            )
            .ForMember(
                dest => dest.Contact,
                opt => opt.MapFrom(src => src.Contact)
            );
    }
}
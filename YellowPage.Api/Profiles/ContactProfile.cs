using AutoMapper;
using YellowPage.Api.Dtos;
using YellowPage.Api.Models;

namespace YellowPage.Api.Profiles;

public class ContactProfile : Profile
{
    public ContactProfile()
    {
        CreateMap<ContactRequestDto, Contact>()
            .ForMember(
                dest => dest.Email,
                opt => opt.MapFrom(src => src.Email)
            )
            .ForMember(
                dest => dest.PhoneNumber,
                opt => opt.MapFrom(src => src.PhoneNumber)
            )
            .ForMember(
                dest => dest.WebSite,
                opt => opt.MapFrom(src => src.WebSite)
            )
            .ForMember(
                dest => dest.Location,
                opt => opt.MapFrom(src => src.Location)
            );
    }
}
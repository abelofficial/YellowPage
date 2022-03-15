using AutoMapper;
using YellowPage.Api.Dtos;
using YellowPage.Api.Models;

namespace YellowPage.Api.Profiles;

public class BusinessProfile : Profile
{
    public BusinessProfile()
    {
        CreateMap<BusinessRequestDto, Business>()
            .ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => src.Name)
            )
            .ForMember(
                dest => dest.Description,
                opt => opt.MapFrom(src => src.Description)
            )
            .ForMember(
                dest => dest.Contact,
                opt => opt.MapFrom(src => src.Contact)
            );
    }
}
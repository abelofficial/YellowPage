using AutoMapper;
using YellowPage.Api.Dtos;
using YellowPage.Api.Models;

namespace YellowPage.Api.Profiles;

public class LocationProfile : Profile
{
    public LocationProfile()
    {
        CreateMap<LocationRequestDto, Location>()
            .ForMember(
                dest => dest.Country,
                opt => opt.MapFrom(src => src.Country)
            )
            .ForMember(
                dest => dest.City,
                opt => opt.MapFrom(src => src.City)
            )
            .ForMember(
                dest => dest.Address,
                opt => opt.MapFrom(src => src.Address)
            )
            .ForMember(
                dest => dest.ZipCode,
                opt => opt.MapFrom(src => src.ZipCode)
            );
    }
}
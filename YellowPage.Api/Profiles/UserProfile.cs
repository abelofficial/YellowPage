using AutoMapper;
using YellowPage.Api.Dtos;
using YellowPage.Api.Models;

namespace YellowPage.Api.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<RegisterUserDto, User>();
    }
}
using AutoMapper;
using Hemera.Chat.Dtos;
using Hemera.Chat.Entities;

namespace Hemera.Chat.Configurations;
public class MapperInitializer : Profile
{
    public MapperInitializer()
    {
        CreateMap<ApplicationUser, ContactInfoDto>().ReverseMap();
    }
}
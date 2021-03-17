using Api.Domain.DTOs.User;
using Api.Domain.Models.User;
using AutoMapper;

namespace Api.CrossCutting.Mappings
{
    public class DtoModelProfile : Profile
    {
        public DtoModelProfile()
        {
            CreateMap<UserModel, UserDtoCreate>().ReverseMap();
            CreateMap<UserModel, UserDto>().ReverseMap();
            CreateMap<UserModel, UserDtoUpdate>().ReverseMap();
        }
    }
}

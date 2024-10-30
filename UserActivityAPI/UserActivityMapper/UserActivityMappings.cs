using AutoMapper;
using UserActivityAPI.Models;
using UserActivityAPI.Models.Dtos;

namespace UserActivityAPI.UserActivityMapper
{
    public class UserActivityMappings: Profile
    {
        public UserActivityMappings()
        {
            CreateMap<User, UserCreateDto>().ReverseMap();
            CreateMap<User, UserUpdateDto>().ReverseMap();
        }
    }
}

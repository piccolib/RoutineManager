using AutoMapper;
using RoutineManager.API.DTOs;
using RoutineManager.API.Entities;

namespace RoutineManager.API.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserDto>();
        CreateMap<CreateUserDto, User>();
    }
}
using AutoMapper;
using RoutineManager.API.DTOs;
using RoutineManager.API.Entities;

namespace RoutineManager.API.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // User Mappings
        CreateMap<User, UserDto>();
        CreateMap<CreateUserDto, User>();
        CreateMap<UpdateUserDto, User>();

        // Habit Mappings
        CreateMap<Habit, HabitDto>();
        CreateMap<CreateHabitDto, Habit>();
        CreateMap<UpdateHabitDto, Habit>();
    }
}

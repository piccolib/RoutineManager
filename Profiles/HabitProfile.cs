using AutoMapper;
using RoutineManager.API.DTOs;
using RoutineManager.API.Entities;

namespace RoutineManager.API.Profiles;

public class HabitProfile : Profile
{
    public HabitProfile()
    {
        CreateMap<Habit, HabitDto>();
        CreateMap<CreateHabitDto, Habit>();
        CreateMap<UpdateHabitDto, Habit>();
    }
}

using AutoMapper;
using RoutineManager.API.DTOs;
using RoutineManager.API.Entities;
using RoutineManager.API.Repositories;
using RoutineManager.API.Repositories.Interfaces;
using RoutineManager.API.Services.Interfaces;

namespace RoutineManager.API.Services;

public class HabitService(IHabitRepository habitRepository, IMapper mapper) : IHabitService
{
    private readonly IHabitRepository _habitRepository = habitRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<HabitDto>> GetHabitsByUserIdAsync(int userId)
    {
        var habits = await _habitRepository.GetByUserIdAsync(userId);
        return _mapper.Map<IEnumerable<HabitDto>>(habits);
    }

    public async Task<HabitDto> GetHabitByIdAsync(int id)
    {
        var habit = await _habitRepository.GetByIdAsync(id);
        return _mapper.Map<HabitDto>(habit);
    }

    public async Task<HabitDto> CreateHabitAsync(CreateHabitDto createHabitDto)
    {
        var habit = _mapper.Map<Habit>(createHabitDto);

        await _habitRepository.AddAsync(habit);
        await _habitRepository.SaveChangesAsync();

        return _mapper.Map<HabitDto>(habit);
    }

    public async Task<bool> UpdateHabitAsync(int id, UpdateHabitDto updateHabitDto)
    {
        var habit = await _habitRepository.GetByIdAsync(id);
        if (habit is null)
            return false;

        _mapper.Map(updateHabitDto, habit);
        await _habitRepository.UpdateAsync(habit);
        return await _habitRepository.SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var user = await _habitRepository.GetByIdAsync(id);
        if (user is null) return false;

        await _habitRepository.DeleteAsync(user);
        return await _habitRepository.SaveChangesAsync();
    }
}

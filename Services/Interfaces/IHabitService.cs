using RoutineManager.API.DTOs;

namespace RoutineManager.API.Services.Interfaces;

public interface IHabitService
{
    Task<IEnumerable<HabitDto>> GetHabitsByUserIdAsync(int userId);
    Task<HabitDto?> GetHabitByIdAsync(int id);
    Task<HabitDto> CreateHabitAsync(CreateHabitDto createHabitDto);
    Task<bool> UpdateHabitAsync(int id, UpdateHabitDto updateHabitDto);
    Task<bool> DeleteAsync(int id);
}

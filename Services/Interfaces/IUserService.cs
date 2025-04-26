using RoutineManager.API.DTOs;
using RoutineManager.API.Entities;

public interface IUserService
{
    Task<UserDto?> GetByIdAsync(int id, bool includeHabits = false);
    Task<UserDto?> GetByEmailAsync(string email);
    Task<bool> UpdateAsync(int id, UpdateUserDto updateDto);
    Task<bool> DeleteAsync(int id);
}
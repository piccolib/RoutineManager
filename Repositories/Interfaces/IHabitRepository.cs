
using RoutineManager.API.Entities;

namespace RoutineManager.API.Repositories.Interfaces;

public interface IHabitRepository
{
    Task<IEnumerable<Habit>> GetByUserIdAsync(int userId);
    Task<Habit?> GetByIdAsync(int id);
    Task AddAsync(Habit habit);
    Task UpdateAsync(Habit habit);
    Task DeleteAsync(Habit habit);
    Task<bool> SaveChangesAsync();
}

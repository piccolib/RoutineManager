
using RoutineManager.API.Entities;

namespace RoutineManager.API.Repositories.Interfaces;

public interface IHabitRepository
{
    Task<IEnumerable<Habit>> GetByUserIdAsync(int userId);
    Task<Habit?> GetByIdAsync(int id);
    Task AddAsync(Habit habit);
    void Update(Habit habit);
    void Delete(Habit habit);
    Task<bool> SaveChangesAsync();
}

namespace RoutineManager.API.Repositories.Interfaces;

using RoutineManager.API.Entities;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(int id, bool includeHabits = false);
    Task<User?> GetByEmailAsync(string email);
    Task AddAsync(User user);
    Task UpdateAsync(User user);
    Task DeleteAsync(User user);
    Task<bool> SaveChangesAsync();
}

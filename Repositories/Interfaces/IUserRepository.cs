using RoutineManager.API.Entities;

namespace RoutineManager.API.Repositories.Interfaces;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetAllAsync();
    Task<User> GetByIdAsync(int id);
    Task AddAsync(User user);
}
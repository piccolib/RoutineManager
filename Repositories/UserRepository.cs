namespace RoutineManager.API.Repositories;

using Microsoft.EntityFrameworkCore;
using RoutineManager.API.Data;
using RoutineManager.API.Entities;
using RoutineManager.API.Repositories.Interfaces;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<User?> GetByIdAsync(int id, bool includeHabits = false)
    {
        if (includeHabits)
        {
            return await _context.Users
                .Include(u => u.Habits)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        return await _context.Users.FindAsync(id);
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _context.Users
            .FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
    }

    public async Task UpdateAsync(User user)
    {
        _context.Users.Update(user);
    }

    public async Task DeleteAsync(User user)
    {
        _context.Users.Remove(user);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}

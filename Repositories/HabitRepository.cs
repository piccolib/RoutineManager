using Microsoft.EntityFrameworkCore;
using RoutineManager.API.Data;
using RoutineManager.API.Entities;
using RoutineManager.API.Repositories.Interfaces;

namespace RoutineManager.API.Repositories;

public class HabitRepository : IHabitRepository
{
    private readonly AppDbContext _context;

    public HabitRepository(AppDbContext context)
    {
        _context = context; 
    }

    public async Task<IEnumerable<Habit>> GetByUserIdAsync(int userId)
    {
        return await _context.Habits
            .Where(h => h.UserId == userId)
            .ToListAsync();
    }

    public async Task<Habit?> GetByIdAsync(int id)
    {
        return await _context.Habits.FirstOrDefaultAsync(h => h.Id == id);
    }

    public async Task AddAsync(Habit habit)
    {
        _context.Habits.Add(habit);
    }

    public async Task UpdateAsync(Habit habit)
    {
        _context.Habits.Update(habit);
    }

    public async Task DeleteAsync(Habit habit)
    {
        _context.Habits.Remove(habit);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}

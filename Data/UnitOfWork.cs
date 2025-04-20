namespace RoutineManager.API.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> CommitAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> SaveChangesAsync()
    {
        try
        {
            var result = await _context.SaveChangesAsync();

            return result > 0;
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("An error occurred while saving changes", ex);
        }
    }
}

public interface IUnitOfWork
{
    Task<bool> CommitAsync();
    Task<bool> SaveChangesAsync();
}


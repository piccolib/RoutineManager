using Microsoft.EntityFrameworkCore;
using RoutineManager.API.Entities;

namespace RoutineManager.API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    // Adicione aqui os DbSets para cada entidade do banco
    public DbSet<User> Users { get; set; }
    public DbSet<Habit> Habits { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configuração adicional das entidades, constraints, seed data etc.
        modelBuilder.Entity<User>()
            .HasMany(h => h.Habits)
            .WithOne()
            .HasForeignKey(h => h.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}




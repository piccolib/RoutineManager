using Microsoft.EntityFrameworkCore;

namespace RoutineManager.API.Data;

public static class DbInitializer
{
    public static void Initialize(AppDbContext context)
    {
        context.Database.Migrate(); // Aplica as migrações automaticamente

        if (!context.Users.Any()) // Se não houver usuários, cria alguns dados iniciais
        {
            context.Users.Add(new Entities.User { Name = "Admin", Email = "admin@routine.com" });
            context.SaveChanges();
        }
    }
}



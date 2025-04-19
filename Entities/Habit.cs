namespace RoutineManager.API.Entities;

public class Habit : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int UserId { get; set; } // Foreign Key
    public User User { get; set; } // User relationship
}

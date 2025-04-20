namespace RoutineManager.API.Entities;

public class User : BaseEntity
{
    public string Name { get; set; }
    public string Email { get; set; }

    public ICollection<Habit> Habits { get; set; } = new List<Habit>();
}

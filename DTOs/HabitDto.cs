using RoutineManager.API.Entities;

namespace RoutineManager.API.DTOs;

public class HabitDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int UserId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}

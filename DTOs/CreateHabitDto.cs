using RoutineManager.API.Entities;

namespace RoutineManager.API.DTOs;

public class CreateHabitDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int UserId { get; set; }
}
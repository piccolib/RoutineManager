using Microsoft.AspNetCore.Mvc;
using RoutineManager.API.DTOs;
using RoutineManager.API.Services;
using RoutineManager.API.Services.Interfaces;

namespace RoutineManager.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HabitController : ControllerBase
{
    private readonly IHabitService _habitService;

    public HabitController(IHabitService habitService)
    {
        _habitService = habitService;
    }

    [HttpGet("user/{userId}")]
    public async Task<ActionResult<IEnumerable<HabitDto>>> GetByUserId(int userId)
    {
        var habits = await _habitService.GetHabitsByUserIdAsync(userId);
        return Ok(habits);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<HabitDto>> GetHabitById(int id)
    {
        var habit = await _habitService.GetHabitByIdAsync(id);

        if (habit == null)
            return NotFound();

        return Ok(habit);
    }

    [HttpPost]
    public async Task<ActionResult<HabitDto>> CreateHabit(CreateHabitDto createHabitDto)
    {
        var createdHabit = await _habitService.CreateHabitAsync(createHabitDto);
        return CreatedAtAction(nameof(GetHabitById), new { id = createdHabit.Id }, createdHabit);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<HabitDto>> UpdateHabit(int id, UpdateHabitDto updateHabitDto)
    {
        var success = await _habitService.UpdateHabitAsync(id, updateHabitDto);
        if (!success)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _habitService.DeleteAsync(id);
        if (!success) return NotFound();

        return NoContent();
    }
}

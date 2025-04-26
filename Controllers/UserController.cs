using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RoutineManager.API.DTOs;
using RoutineManager.API.Services.Interfaces;

namespace RoutineManager.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id, [FromQuery] bool includeHabits = false)
    {
        var user = await _userService.GetByIdAsync(id, includeHabits);
        if (user is null) 
            return NotFound();

        return Ok(user);
    }

    [HttpGet("by-email")]
    public async Task<IActionResult> GetByEmail([FromQuery] string email)
    {
        var user = await _userService.GetByEmailAsync(email);
        if (user is null)
            return NotFound();

        return Ok(user);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateUserDto dto)
    {
        var success = await _userService.UpdateAsync(id, dto);
        if (!success) 
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _userService.DeleteAsync(id);
        if (!success) return NotFound();

        return NoContent();
    }
}

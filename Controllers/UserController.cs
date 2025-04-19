using Microsoft.AspNetCore.Mvc;
using RoutineManager.API.DTOs;
using RoutineManager.API.Services.Interfaces;

namespace RoutineManager.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetAllUsers()
    {
        return Ok(await _userService.GetAllUsersAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserDto>> GetUserById(int id)
    {
        var user = await _userService.GetUserByIdAsync(id);
        if (user == null) return NotFound();
        return Ok(user);
    }

    [HttpPost]
    public async Task<ActionResult<UserDto>> CreateUser(CreateUserDto createUserDto)
    {
        var createdUser = await _userService.CreateUserAsync(createUserDto);
        return CreatedAtAction(nameof(GetUserById), new { id = createdUser.Id }, createdUser);
    }
}

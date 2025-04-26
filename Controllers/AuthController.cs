namespace RoutineManager.API.Controllers;

using Microsoft.AspNetCore.Mvc;
using RoutineManager.API.DTOs;
using RoutineManager.API.Services.Interfaces;

[ApiController]
[Route("auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(CreateUserDto createUserDto)
    {
        var user = await _authService.RegisterAsync(createUserDto);
        if (user == null)
            return BadRequest("Usuário já existe.");

        return Ok(user);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto loginDto)
    {
        var token = await _authService.LoginAsync(loginDto);
        if (token == null)
            return Unauthorized("Credenciais inválidas.");

        return Ok(new { Token = token });
    }
}

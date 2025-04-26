namespace RoutineManager.API.Services.Interfaces;

using RoutineManager.API.DTOs;
using RoutineManager.API.Entities;

public interface IAuthService
{
    Task<string?> LoginAsync(LoginDto loginDto);
    Task<UserDto?> RegisterAsync(CreateUserDto createUserDto);
}

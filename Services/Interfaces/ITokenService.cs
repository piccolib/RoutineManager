using RoutineManager.API.Entities;

namespace RoutineManager.API.Services.Interfaces;

public interface ITokenService
{
    string GenerateToken(User user);
}

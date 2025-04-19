using AutoMapper;
using RoutineManager.API.DTOs;
using RoutineManager.API.Entities;
using RoutineManager.API.Repositories.Interfaces;
using RoutineManager.API.Services.Interfaces;

namespace RoutineManager.API.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
    {
        var users = await _userRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<UserDto>>(users);
    }

    public async Task<UserDto> GetUserByIdAsync(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        return _mapper.Map<UserDto>(user);
    }

    public async Task<UserDto> CreateUserAsync(CreateUserDto createUserDto)
    {
        var user = _mapper.Map<User>(createUserDto);
        user.CreatedAt = DateTime.Now;
        await _userRepository.AddAsync(user);
        return _mapper.Map<UserDto>(user);
    }
}

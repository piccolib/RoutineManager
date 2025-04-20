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

    public async Task<UserDto?> GetByIdAsync(int id, bool includeHabits = false)
    {
        var user = await _userRepository.GetByIdAsync(id, includeHabits);
        return user is null ? null : _mapper.Map<UserDto>(user);
    }

    public async Task<UserDto?> GetByEmailAsync(string email)
    {
        var user = await _userRepository.GetByEmailAsync(email);
        return user is null ? null : _mapper.Map<UserDto>(user);
    }

    public async Task<UserDto> CreateAsync(CreateUserDto createDto)
    {
        var user = _mapper.Map<User>(createDto);

        await _userRepository.AddAsync(user);
        await _userRepository.SaveChangesAsync();

        return _mapper.Map<UserDto>(user);
    }

    public async Task<bool> UpdateAsync(int id, UpdateUserDto updateDto)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user is null)
            return false;

        _mapper.Map(updateDto, user);
        await _userRepository.UpdateAsync(user);
        return await _userRepository.SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user is null) return false;

        await _userRepository.DeleteAsync(user);
        return await _userRepository.SaveChangesAsync();
    }
}

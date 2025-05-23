﻿using AutoMapper;
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

    public async Task<bool> UpdateAsync(int id, UpdateUserDto updateDto)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user is null)
            return false;

        _mapper.Map(updateDto, user);
        _userRepository.Update(user);
        return await _userRepository.SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user is null) return false;

        _userRepository.Delete(user);
        return await _userRepository.SaveChangesAsync();
    }
}

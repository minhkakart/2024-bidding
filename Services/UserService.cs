namespace WebApi.Services;

using AutoMapper;
using BCrypt.Net;
using WebApi.DTOs;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models.Users;
using WebApi.Repositories;

public interface IUserService
{
	Task<IEnumerable<UserDTO>> GetAll();
	Task<UserDTO> GetById(int id);
	Task Create(UserCreateRequest model);
	Task Update(int id, UserUpdateRequest model);
	Task Delete(int id);
}

public class UserService(
	IUserRepository userRepository,
	IMapper mapper) : IUserService
{
	private readonly IUserRepository _userRepository = userRepository;
	private readonly IMapper _mapper = mapper;

	public async Task<IEnumerable<UserDTO>> GetAll()
	{
		return await _userRepository.GetAll();
	}

	public async Task<UserDTO> GetById(int id)
	{
		var user = await _userRepository.GetById(id);

		return user ?? throw new KeyNotFoundException("User not found");
	}

	public async Task Create(UserCreateRequest model)
	{
		/*// validate
        if (await _userRepository.GetByEmail(model.Email!) != null)
            throw new AppException("User with the email '" + model.Email + "' already exists");*/

		// map model to new user object
		var user = _mapper.Map<User>(model);

		// hash password
		user.PasswordHash = BCrypt.HashPassword(model.password);

		// save user
		await _userRepository.Create(user);
	}

	public async Task Update(int id, UserUpdateRequest model)
	{
		var user = await _userRepository.GetById(id) ?? throw new KeyNotFoundException("User not found");

		/*// validate
        var emailChanged = !string.IsNullOrEmpty(model.Email) && user.Email != model.Email;
        if (emailChanged && await _userRepository.GetByEmail(model.Email!) != null)
            throw new AppException("User with the email '" + model.Email + "' already exists");*/

		// hash password if it was entered
		if (!string.IsNullOrEmpty(model.Password))
			user.PasswordHash = BCrypt.HashPassword(model.Password);

		// copy model props to user
		_mapper.Map(model, user);
		var u = _mapper.Map<User>(user);

		// save user
		await _userRepository.Update(u);

	}

	public async Task Delete(int id)
	{
		await _userRepository.Delete(id);
	}

}
namespace WebApi.Repositories;

using AutoMapper;
using Dapper;
using WebApi.DTOs;
using WebApi.Entities;
using WebApi.Helpers;

public interface IUserRepository
{
    Task<IEnumerable<UserDTO>> GetAll();
    Task<UserDTO> GetById(int id);
    /*Task<User> GetByEmail(string email);*/
    Task Create(User user);
    Task Update(User user);
    Task Delete(int id);
}

public class UserRepository(DataContext context, IMapper mapper) : IUserRepository
{
	private readonly DataContext _context = context;
	private readonly IMapper _mapper = mapper;

	public async Task<IEnumerable<UserDTO>> GetAll()
    {
        using var connection = _context.CreateConnection();
        /*var sql = """
            SELECT * FROM User
        """;
        return await connection.QueryAsync<User>(sql);*/

        // using DTO
        /*var dtoSql = """
			SELECT *
			FROM User AS u
			JOIN UserGroup AS ug ON u.group_id = ug.group_id
		""";

        var userDTO = await connection.QueryAsync(dtoSql);
        var userDTOList = new List<UserDTO>();

        foreach (var user in userDTO)
        {
            var uDTO = new UserDTO();
            uDTO.user_id = Convert.ToInt32(user.user_id);
            uDTO.group_id = Convert.ToInt32(user.group_id);
            uDTO.username = user.username;
            uDTO.UserGroup = new UserGroup();
            uDTO.UserGroup.group_id = Convert.ToInt32(user.group_id);
            uDTO.UserGroup.group_name = user.group_name;

            userDTOList.Add(uDTO);
        }*/

        // using Dapper's multi-mapping
        var dtoSql = @"
			SELECT u.*, ug.*, up.*
			FROM User AS u
			JOIN UserGroup AS ug ON u.group_id = ug.group_id
			JOIN UserProfile AS up ON u.user_id = up.user_id";

        var users = await connection.QueryAsync<User, UserGroup, UserProfile, UserDTO>(dtoSql, (u, ug, up) => {
            var dto = _mapper.Map<UserDTO>(u);
            dto.UserGroup = ug;
            dto.UserProfile = up;
            return dto;
        }, splitOn: "group_id, profile_id");
        return users;

    }

    public async Task<UserDTO> GetById(int id)
    {
        using var connection = _context.CreateConnection();
        var sql = @"
			SELECT u.*, ug.*, up.*
			FROM User AS u
			JOIN UserGroup AS ug ON u.group_id = ug.group_id
			JOIN UserProfile AS up ON u.user_id = up.user_id
            WHERE u.user_id = @id";
		var user = await connection.QueryAsync<User, UserGroup, UserProfile, UserDTO>(sql,
            (u, ug, up) =>
            {
				var dto = _mapper.Map<UserDTO>(u);
				dto.UserGroup = ug;
				dto.UserProfile = up;
				return dto;
			}, new { id }, splitOn: "group_id, profile_id");

        return user.FirstOrDefault(new UserDTO());

    }

    public async Task Create(User user)
    {
        using var connection = _context.CreateConnection();
        var sql = """
            INSERT INTO User (group_id, username, password)
            VALUES (@group_id, @username, @PasswordHash)
        """;
        await connection.ExecuteAsync(sql, user);
    }

    public async Task Update(User user)
    {
        using var connection = _context.CreateConnection();
        var sql = """
            UPDATE User
            SET group_id = @group_id,
                username = @username,
                password = @PasswordHash
            WHERE Id = @Id
        """;
        await connection.ExecuteAsync(sql, user);
    }

    public async Task Delete(int id)
    {
        using var connection = _context.CreateConnection();
        var sql = """
            DELETE FROM User
            WHERE user_id = @id
        """;
        await connection.ExecuteAsync(sql, new { id });
    }
}
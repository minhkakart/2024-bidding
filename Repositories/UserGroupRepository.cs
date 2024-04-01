namespace WebApi.Repositories
{
	using Dapper;
	using WebApi.Entities;
	using WebApi.Helpers;

	public interface IUserGroupRepository
	{
		Task<IEnumerable<UserGroup>> GetAll();
		Task<UserGroup> GetById(int id);
		Task Create(UserGroup userGroup);
		Task Update(UserGroup userGroup);
		Task Delete(int id);
	}

	public class UserGroupRepository(DataContext context) : IUserGroupRepository
	{
		public DataContext _context = context;

		public async Task<IEnumerable<UserGroup>> GetAll()
		{
			using var connection = _context.CreateConnection();
			var sql = "SELECT * FROM UserGroup";
			return await connection.QueryAsync<UserGroup>(sql);
		}

		public async Task<UserGroup> GetById(int id)
		{
			using var connection = _context.CreateConnection();
			var sql = @"SELECT * FROM UserGroup 
						WHERE group_id = @group_id";
			return await connection.QueryFirstOrDefaultAsync<UserGroup>(sql, new { group_id = id });
		}

		public async Task Create(UserGroup userGroup)
		{
			using var connection = _context.CreateConnection();
			var sql = "INSERT INTO UserGroup (group_name) VALUES (@group_name)";
			await connection.ExecuteAsync(sql, userGroup);
		}

		public async Task Update(UserGroup userGroup)
		{
			using var connection = _context.CreateConnection();
			var sql = @"UPDATE UserGroup SET 
						group_name = @group_name 
						WHERE group_id = @group_id";
			await connection.ExecuteAsync(sql, userGroup);
		}

		public async Task Delete(int id)
		{
			using var connection = _context.CreateConnection();
			var sql = "DELETE FROM UserGroup WHERE group_id = @group_id";
			await connection.ExecuteAsync(sql, new { group_id = id });
		}

	}
}

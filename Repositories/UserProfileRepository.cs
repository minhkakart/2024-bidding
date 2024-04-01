namespace WebApi.Repositories
{
	using Dapper;
	using WebApi.Entities;
	using WebApi.Helpers;

	public interface IUserProfileRepository
	{
		Task<IEnumerable<UserProfile>> GetAll();
		Task<UserProfile> GetById(int id);
		Task Create(UserProfile userProfile);
		Task Update(UserProfile userProfile);
		Task Delete(int id);
	}

	public class UserProfileRepository(DataContext context) : IUserProfileRepository
	{
		public DataContext _context = context;

		public async Task<IEnumerable<UserProfile>> GetAll()
		{
			using var connection = _context.CreateConnection();
			var sql = "SELECT * FROM UserProfile";
			return await connection.QueryAsync<UserProfile>(sql);
		}

		public async Task<UserProfile> GetById(int id)
		{
			using var connection = _context.CreateConnection();
			var sql = @"SELECT * FROM UserProfile 
						WHERE profile_id = @profile_id";
			return await connection.QueryFirstOrDefaultAsync<UserProfile>(sql, new { profile_id = id });
		}

		public async Task Create(UserProfile userProfile)
		{
			using var connection = _context.CreateConnection();
			var sql = @"INSERT INTO UserProfile (user_id, fullname, phone, email, address) 
						VALUES (@user_id, @fullname, @phone, @email, @address)";
			await connection.ExecuteAsync(sql, userProfile);
		}

		public async Task Update(UserProfile userProfile)
		{
			using var connection = _context.CreateConnection();
			var sql = @"UPDATE UserProfile SET 
						fullname = @fullname, 
						phone = @phone, 
						email = @email, 
						address = @address 
						WHERE user_id = @user_id";
			await connection.ExecuteAsync(sql, userProfile);
		}

		public async Task Delete(int id)
		{
			using var connection = _context.CreateConnection();
			var sql = "DELETE FROM UserProfile WHERE user_id = @user_id";
			await connection.ExecuteAsync(sql, new { user_id = id });
		}

	}
}

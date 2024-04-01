namespace WebApi.Repositories
{
	using Dapper;
	using WebApi.Entities;
	using WebApi.Helpers;

	public interface ITagRepository
	{
		Task<IEnumerable<Tag>> GetAll();
		Task<Tag> GetById(int id);
		Task Create(Tag tag);
		Task Update(Tag tag);
		Task Delete(int id);
	}

	public class TagRepository(DataContext context) : ITagRepository
	{
		private readonly DataContext _context = context;

		public async Task<IEnumerable<Tag>> GetAll()
		{
			using var connection = _context.CreateConnection();
			var sql = "SELECT * FROM Tag";
			return await connection.QueryAsync<Tag>(sql);
		}

		public async Task<Tag> GetById(int id)
		{
			using var connection = _context.CreateConnection();
			var sql = @"SELECT * FROM Tag 
						WHERE tag_id = @tag_id";
			return await connection.QueryFirstOrDefaultAsync<Tag>(sql, new { tag_id = id });
		}

		public async Task Create(Tag tag)
		{
			using var connection = _context.CreateConnection();
			var sql = "INSERT INTO Tag (tag_name) VALUES (@tag_name)";
			await connection.ExecuteAsync(sql, tag);
		}

		public async Task Update(Tag tag)
		{
			using var connection = _context.CreateConnection();
			var sql = "UPDATE Tag SET tag_name = @tag_name WHERE tag_id = @tag_id";
			await connection.ExecuteAsync(sql, tag);
		}

		public async Task Delete(int id)
		{
			using var connection = _context.CreateConnection();
			var sql = "DELETE FROM Tag WHERE tag_id = @tag_id";
			await connection.ExecuteAsync(sql, new { tag_id = id });
		}
	}
}

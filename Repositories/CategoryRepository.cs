namespace WebApi.Repositories
{
	using Dapper;
	using WebApi.Entities;
	using WebApi.Helpers;

	public interface ICategoryRepository
	{
		Task<IEnumerable<Category>> GetAll();
		Task<Category> GetById(int id);
		Task Create(Category category);
		Task Update(Category category);
		Task Delete(int id);
	}
	public class CategoryRepository(DataContext context) : ICategoryRepository
	{
		private readonly DataContext _context = context;

		public async Task<IEnumerable<Category>> GetAll()
		{
			using var connection = _context.CreateConnection();
			var sql = @"
				SELECT * FROM Category
			";
			return await connection.QueryAsync<Category>(sql);
		}
		public async Task<Category> GetById(int id)
		{
			using var connection = _context.CreateConnection();
			var sql = @"
				SELECT * FROM Category
				WHERE category_id = @id
			";
			return await connection.QuerySingleOrDefaultAsync<Category>(sql, new { id });
		}
		public async Task Create(Category category)
		{
			using var connection = _context.CreateConnection();
			var sql = @"
				INSERT INTO Category (category_name)
				VALUES (@category_name)
			";
			await connection.ExecuteAsync(sql, category);
		}
		public async Task Update(Category category)
		{
			using var connection = _context.CreateConnection();
			var sql = @"
				UPDATE Category
				SET category_name = @category_name
				WHERE category_id = @category_id
			";
			await connection.ExecuteAsync(sql, category);
		}

		public async Task Delete(int id)
		{
			using var connection = _context.CreateConnection();
			var sql = @"
				DELETE FROM Category
				WHERE category_id = @id
			";
			await connection.ExecuteAsync(sql, new { id });
		}
	}
}

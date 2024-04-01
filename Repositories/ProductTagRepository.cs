namespace WebApi.Repositories
{
	using Dapper;
	using WebApi.Entities;
	using WebApi.Helpers;

	public interface IProductTagRepository
	{
		Task<IEnumerable<ProductTag>> GetAll();
		Task<ProductTag> GetById(int id);
		Task<int> Create(ProductTag productTag);
		Task<int> Update(ProductTag productTag);
		Task<int> Delete(int id);
	}

	public class ProductTagRepository(DataContext context) : IProductTagRepository
	{
		private readonly DataContext _context = context;

		public async Task<IEnumerable<ProductTag>> GetAll()
		{
			using var connection = _context.CreateConnection();
			var sql = @"SELECT * FROM ProductTag";
			return await connection.QueryAsync<ProductTag>(sql);
		}

		public async Task<ProductTag> GetById(int id)
		{
			using var connection = _context.CreateConnection();
			var sql = @"SELECT * FROM ProductTag 
						WHERE product_tag_id = @product_tag_id";
			return await connection.QueryFirstOrDefaultAsync<ProductTag>(sql, new { product_tag_id = id });
		}

		public async Task<int> Create(ProductTag productTag)
		{
			using var connection = _context.CreateConnection();
			var sql = @"INSERT INTO ProductTag (product_id, tag_id)
						VALUES (@product_id, @tag_id)";
			return await connection.ExecuteAsync(sql, productTag);
		}

		public async Task<int> Update(ProductTag productTag)
		{
			using var connection = _context.CreateConnection();
			var sql = @"UPDATE ProductTag SET
						product_id = @product_id, 
						tag_id = @tag_id 
						WHERE product_tag_id = @product_tag_id";
			return await connection.ExecuteAsync(sql, productTag);
		}

		public async Task<int> Delete(int id)
		{
			using var connection = _context.CreateConnection();
			var sql = @"DELETE FROM ProductTag 
						WHERE product_tag_id = @product_tag_id";
			return await connection.ExecuteAsync(sql, new { product_tag_id = id });
		}
	}
}

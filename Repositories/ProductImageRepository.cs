namespace WebApi.Repositories
{
	using Dapper;
	using WebApi.Entities;
	using WebApi.Helpers;

	public interface IProductImageRepository
	{
		Task<ProductImage> GetById(int id);
		Task<IEnumerable<ProductImage>> GetAll();
		Task Create(ProductImage productImage);
		Task Update(ProductImage productImage);
		Task Delete(int id);
	}
	public class ProductImageRepository(DataContext context) : IProductImageRepository
	{
		private readonly DataContext _context = context;

		public async Task Create(ProductImage productImage)
		{
			using var connection = _context.CreateConnection();
			var sql = @"INSERT INTO productimage (product_id, image_url)
						VALUES (@product_id, @image_url)";
			await connection.ExecuteAsync(sql, productImage);
		}

		public async Task Delete(int id)
		{
			var connection = _context.CreateConnection();
			var sql = @"DELETE FROM productimage 
						WHERE image_id = @id";
			await connection.ExecuteAsync(sql, new { id });
		}

		public async Task<IEnumerable<ProductImage>> GetAll()
		{
			var connection = _context.CreateConnection();
			var sql = @"SELECT * FROM productimage";
			return await connection.QueryAsync<ProductImage>(sql);
		}

		public async Task<ProductImage> GetById(int id)
		{
			var connection = _context.CreateConnection();
			var sql = @"SELECT * FROM productimage 
						WHERE image_id = @id";
			return await connection.QuerySingleOrDefaultAsync<ProductImage>(sql, new { id });
		}

		public async Task Update(ProductImage productImage)
		{
			var connection = _context.CreateConnection();
			var sql = @"UPDATE productimage SET 
						product_id = @product_id, 
						image_url = @image_url 
						WHERE image_id = @image_id";
			await connection.ExecuteAsync(sql, productImage);
		}
	}
}

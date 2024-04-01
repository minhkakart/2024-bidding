namespace WebApi.Repositories;

using Dapper;
using WebApi.Entities;
using WebApi.Helpers;
public interface IAuthorRepository
{
	Task<IEnumerable<Author>> GetAll();
	Task<Author> GetById(int id);
	Task Create(Author author);
	Task Update(Author author);
	Task Delete(int id);
}
public class AuthorRepository(DataContext context) : IAuthorRepository
{
	private readonly DataContext _context = context;

	public async Task<IEnumerable<Author>> GetAll()
	{
		using var connection = _context.CreateConnection();
		var sql = @"
			SELECT * FROM Author
		";
		return await connection.QueryAsync<Author>(sql);
	}
	public async Task<Author> GetById(int id)
	{
		using var connection = _context.CreateConnection();
		var sql = @"
			SELECT * FROM Author
			WHERE author_id = @id
		";
		return await connection.QuerySingleOrDefaultAsync<Author>(sql, new { id });
	}
	public async Task Create(Author author)
	{
		using var connection = _context.CreateConnection();
		var sql = @"
			INSERT INTO Author (author_name)
			VALUES (@author_name)
		";
		await connection.ExecuteAsync(sql, author);
	}
	public async Task Update(Author author)
	{
		using var connection = _context.CreateConnection();
		var sql = @"
			UPDATE Author
			SET author_name = @author_name
			WHERE author_id = @author_id
		";
		await connection.ExecuteAsync(sql, author);
	}

	public async Task Delete(int id)
	{
		using var connection = _context.CreateConnection();
		var sql = @"
			DELETE FROM Author
			WHERE author_id = @id
		";
		await connection.ExecuteAsync(sql, new { id });
	}
}

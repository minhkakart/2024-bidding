using WebApi.Entities;
using WebApi.Repositories;

namespace WebApi.Services
{
	public interface IAuthorService
	{
		Task<IEnumerable<Author>> GetAll();
		Task<Author> GetById(int id);
		Task Create(Author author);
		Task Update(Author author);
		Task Delete(int id);
	}
	public class AuthorService(IAuthorRepository authorRepository) : IAuthorService
	{
		private readonly IAuthorRepository _authorRepository = authorRepository;
		public async Task Create(Author author)
		{
			await _authorRepository.Create(author);
		}

		public async Task Delete(int id)
		{
			await _authorRepository.Delete(id);
		}

		public async Task<IEnumerable<Author>> GetAll()
		{
			return await _authorRepository.GetAll();
		}

		public async Task<Author> GetById(int id)
		{
			return await _authorRepository.GetById(id);
		}

		public async Task Update(Author author)
		{
			await _authorRepository.Update(author);
		}
	}
}

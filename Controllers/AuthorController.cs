using Microsoft.AspNetCore.Mvc;
using WebApi.Entities;
using WebApi.Services;

namespace WebApi.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class AuthorController(IAuthorService authorService) : ControllerBase
	{
		private readonly IAuthorService _authorService = authorService;

		[HttpGet]
		public async Task<IEnumerable<Author>> GetAll()
		{
			return await _authorService.GetAll();
		}
		[HttpGet("{id}")]
		public async Task<Author> GetById(int id)
		{
			return await _authorService.GetById(id);
		}
		[HttpPost]
		public async Task Create(Author author)
		{
			await _authorService.Create(author);
		}
		[HttpPut]
		public async Task Update(Author author)
		{
			await _authorService.Update(author);
		}
		[HttpDelete("{id}")]
		public async Task Delete(int id)
		{
			await _authorService.Delete(id);
		}
	}
}

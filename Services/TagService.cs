using WebApi.Entities;
using WebApi.Repositories;

namespace WebApi.Services
{
	public interface ITagService
	{
		Task<IEnumerable<Tag>> GetAll();
		Task<Tag> GetById(int id);
		Task Create(Tag tag);
		Task Update(Tag tag);
		Task Delete(int id);
	}
	public class TagService(ITagRepository tagRepository) : ITagService
	{
		private readonly ITagRepository _tagRepository = tagRepository;

		public async Task Create(Tag tag)
		{
			await _tagRepository.Create(tag);
		}

		public async Task Delete(int id)
		{
			await _tagRepository.Delete(id);
		}

		public async Task<IEnumerable<Tag>> GetAll()
		{
			return await _tagRepository.GetAll();
		}

		public async Task<Tag> GetById(int id)
		{
			return await _tagRepository.GetById(id);
		}

		public async Task Update(Tag tag)
		{
			await _tagRepository.Update(tag);
		}
	}
}

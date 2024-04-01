using WebApi.Entities;
using WebApi.Repositories;

namespace WebApi.Services
{
	public interface ICategoryService
	{
		Task<IEnumerable<Category>> GetAll();
		Task<Category> GetById(int id);
		Task Create(Category category);
		Task Update(Category category);
		Task Delete(int id);
	}
	public class CategoryService(ICategoryRepository categoryRepository) : ICategoryService
	{
		private readonly ICategoryRepository _categoryRepository = categoryRepository;
		public async Task Create(Category category)
		{
			await _categoryRepository.Create(category);
		}

		public async Task Delete(int id)
		{
			await _categoryRepository.Delete(id);
		}

		public async Task<IEnumerable<Category>> GetAll()
		{
			return await _categoryRepository.GetAll();
		}

		public async Task<Category> GetById(int id)
		{
			return await _categoryRepository.GetById(id);
		}

		public async Task Update(Category category)
		{
			await _categoryRepository.Update(category);
		}
	}
}

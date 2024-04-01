using MySqlX.XDevAPI.Common;
using WebApi.DTOs;
using WebApi.Entities;
using WebApi.Repositories;

namespace WebApi.Services
{
	public interface IProductService
	{
		Task<IEnumerable<ProductDTO>> GetAll();
		Task<ProductDTO> GetById(int id);
		Task Create(Product product);
		Task Update(Product product);
		Task Delete(int id);
		Task<IEnumerable<ProductDTO>> GetAllByCategory(int category_id);
		Task<IEnumerable<ProductDTO>> GetAllByAuthor(int author_id);
	}
	public class ProductService(IProductRepository productRepository) : IProductService
	{
		private readonly IProductRepository _productRepository = productRepository;

		public Task Create(Product product)
		{
			throw new NotImplementedException();
		}

		public Task Delete(int id)
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<ProductDTO>> GetAll()
		{
			return await _productRepository.GetAll();
		}

		public async Task<IEnumerable<ProductDTO>> GetAllByAuthor(int author_id)
		{
			return await _productRepository.GetAllByAuthor(author_id);
		}

		public async Task<IEnumerable<ProductDTO>> GetAllByCategory(int category_id)
		{
			return await _productRepository.GetAllByCategory(category_id);
		}

		public async Task<ProductDTO> GetById(int id)
		{
			return await _productRepository.GetById(id);
		}

		public Task Update(Product product)
		{
			throw new NotImplementedException();
		}
	}
}

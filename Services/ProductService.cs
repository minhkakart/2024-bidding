using MySqlX.XDevAPI.Common;
using WebApi.DTOs;
using WebApi.Entities;
using WebApi.Repositories;

namespace WebApi.Services
{
	public interface IProductService
	{
		Task<PaginateProduct> GetAll(int page);
		Task<ProductDTO> GetById(int id);
		Task Create(Product product);
		Task Update(Product product);
		Task Delete(int id);
		Task<IEnumerable<ProductDTO>> GetAllByCategory(int category_id);
		Task<IEnumerable<ProductDTO>> GetAllByAuthor(int author_id);
		Task<PaginateProduct> SearchByName(string name, int page);
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

		public async Task<PaginateProduct> GetAll(int page)
		{
			return await _productRepository.GetAll(page);
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

		public async Task<PaginateProduct> SearchByName(string name, int page)
		{
			return await _productRepository.SearchByName(name, page);
		}

		public Task Update(Product product)
		{
			throw new NotImplementedException();
		}
	}
}

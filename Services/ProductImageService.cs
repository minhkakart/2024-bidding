using WebApi.Entities;
using WebApi.Repositories;

namespace WebApi.Services
{
	public interface IProductImageService
	{
		Task<ProductImage> GetById(int id);
		Task<IEnumerable<ProductImage>> GetAll();
		Task Create(ProductImage productImage);
		Task Update(ProductImage productImage);
		Task Delete(int id);
	}
	public class ProductImageService(IProductImageRepository productImageRepository) : IProductImageService
	{
		private readonly IProductImageRepository _productImageRepository = productImageRepository;

		public async Task Create(ProductImage productImage)
		{
			await _productImageRepository.Create(productImage);
		}

		public async Task Delete(int id)
		{
			await _productImageRepository.Delete(id);
		}

		public async Task<IEnumerable<ProductImage>> GetAll()
		{
			return await _productImageRepository.GetAll();
		}

		public async Task<ProductImage> GetById(int id)
		{
			return await _productImageRepository.GetById(id);
		}

		public async Task Update(ProductImage productImage)
		{
			await _productImageRepository.Update(productImage);
		}
	}
}
